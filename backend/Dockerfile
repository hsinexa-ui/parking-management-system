# ==========================================
# Stage 1: Build
# ==========================================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

# Copy project file
COPY backend.csproj .

# Restore dependencies
RUN dotnet restore

# Copy source code
COPY . .

# Build and publish application
RUN dotnet publish -c Release -o /app/publish


# ==========================================
# Stage 2: Runtime
# ==========================================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

WORKDIR /app

# Application listens on port 8080
ENV ASPNETCORE_HTTP_PORTS=8080

# Create directory for SQLite database
RUN mkdir -p /app/data

# Copy published application
COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "backend.dll"]