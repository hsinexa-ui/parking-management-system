using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add OpenAPI
builder.Services.AddOpenApi();

// Add SQLite database
builder.Services.AddDbContext<ParkingDbContext>(options =>
    options.UseSqlite("Data Source=parking.db"));

// Allow frontend to communicate with backend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Enable CORS
app.UseCors("AllowFrontend");

// Create SQLite database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ParkingDbContext>();

    db.Database.EnsureCreated();
}

// GET all parking records
app.MapGet("/api/parking", async (ParkingDbContext db) =>
{
    var records = await db.ParkingRecords
        .OrderByDescending(x => x.Id)
        .ToListAsync();

    return Results.Ok(records);
});

// POST a parking record
app.MapPost("/api/parking", async (
    ParkingRequest request,
    ParkingDbContext db) =>
{
    if (string.IsNullOrWhiteSpace(request.VehicleNumber))
    {
        return Results.BadRequest(new
        {
            message = "Vehicle number is required."
        });
    }

    if (string.IsNullOrWhiteSpace(request.VehicleType))
    {
        return Results.BadRequest(new
        {
            message = "Vehicle type is required."
        });
    }

    var record = new ParkingRecord
    {
        VehicleNumber = request.VehicleNumber,
        VehicleType = request.VehicleType,
        EntryTime = DateTime.Now,
        Status = "Parked"
    };

    db.ParkingRecords.Add(record);

    await db.SaveChangesAsync();

    return Results.Ok(record);
});

app.Run();


// Request model
public record ParkingRequest(
    string VehicleNumber,
    string VehicleType
);


// Parking record model
public class ParkingRecord
{
    public int Id { get; set; }

    public string VehicleNumber { get; set; } = "";

    public string VehicleType { get; set; } = "";

    public DateTime EntryTime { get; set; }

    public string Status { get; set; } = "";
}