using System.Reflection;
using Domain.Entities.UserRelated;
using Domain.Entities.VehicleRelated;
using Domain.Entities.VehicleRelated.LocationRelated;
using Domain.Entities.VehicleRelated.TypeRelated;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext.Configurations;

namespace Persistence.Contexts.ApplicationDatabaseContext;

public sealed class ApplicationDatabaseContext(
    DbContextOptions<ApplicationDatabaseContext> options) : IdentityDbContext<User, UserRole, Guid>(options)
{
    internal DbSet<Vehicle> Vehicles { get; set; } = null!;
    internal DbSet<VehicleBrand> VehiclesBrands { get; set; } = null!;
    internal DbSet<VehicleColor> VehicleColors { get; set; } = null!;
    internal DbSet<VehicleModel> VehicleModels { get; set; } = null!;
    internal DbSet<VehiclePrice> VehiclePrices { get; set; } = null!;
    internal DbSet<VehicleType> VehicleTypes { get; set; } = null!;
    internal DbSet<VehicleBodyType> VehicleBodyTypes { get; set; } = null!;
    internal DbSet<VehicleEngineType> VehicleEngineTypes { get; set; } = null!;
    internal DbSet<VehicleDrivetrainType> VehicleDrivetrainTypes { get; set; } = null!;
    internal DbSet<VehicleTransmissionType> VehicleTransmissionTypes { get; set; } = null!;
    internal DbSet<VehicleLocationTownType> VehicleLocationTownTypes { get; set; } = null!;
    internal DbSet<VehicleLocationTown> VehicleLocationTowns { get; set; } = null!;
    internal DbSet<VehicleLocationArea> VehicleLocationAreas { get; set; } = null!;
    internal DbSet<VehicleLocationRegion> VehicleLocationRegions { get; set; } = null!;
    internal DbSet<VehicleImage> VehicleImages { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(DatabaseSchemas.IdentitySchema);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}