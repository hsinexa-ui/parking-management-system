using Microsoft.EntityFrameworkCore;

public class ParkingDbContext : DbContext
{
    public ParkingDbContext(
        DbContextOptions<ParkingDbContext> options)
        : base(options)
    {
    }

    public DbSet<ParkingRecord> ParkingRecords => Set<ParkingRecord>();
}