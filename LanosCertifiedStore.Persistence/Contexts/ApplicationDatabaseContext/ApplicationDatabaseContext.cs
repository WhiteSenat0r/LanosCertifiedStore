using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities.IdentityRelated;
using Persistence.Entities.UserRelated;
using Persistence.Entities.VehicleRelated;
using Persistence.Entities.VehicleRelated.LocationRelated;
using Persistence.Entities.VehicleRelated.TypeRelated;

namespace Persistence.Contexts.ApplicationDatabaseContext;

public sealed class ApplicationDatabaseContext(
    DbContextOptions<ApplicationDatabaseContext> options) : DbContext(options)
{
    internal DbSet<VehicleEntity> Vehicles { get; set; } = null!;
    internal DbSet<VehicleBrandEntity> VehiclesBrands { get; set; } = null!;
    internal DbSet<VehicleColorEntity> VehiclesColors { get; set; } = null!;
    internal DbSet<VehicleModelEntity> VehicleModels { get; set; } = null!;
    internal DbSet<VehiclePriceEntity> VehiclePrices { get; set; } = null!;
    internal DbSet<VehicleTypeEntity> VehicleTypes { get; set; } = null!;
    internal DbSet<VehicleBodyTypeEntity> VehicleBodyTypes { get; set; } = null!;
    internal DbSet<VehicleEngineTypeEntity> VehicleEngineTypes { get; set; } = null!;
    internal DbSet<VehicleDrivetrainTypeEntity> VehicleDrivetrainTypes { get; set; } = null!;
    internal DbSet<VehicleTransmissionTypeEntity> VehicleTransmissionTypes { get; set; } = null!;
    internal DbSet<VehicleLocationTownEntity> VehicleLocationTowns { get; set; } = null!;
    internal DbSet<VehicleLocationAreaEntity> VehicleLocationAreas { get; set; } = null!;
    internal DbSet<VehicleLocationRegionEntity> VehicleLocationRegions { get; set; } = null!;
    internal DbSet<VehicleImageEntity> VehicleImages { get; set; } = null!;
    internal DbSet<UserEntity> Users { get; set; } = null!;
    internal DbSet<UserRoleEntity> Roles { get; set; } = null!;
    internal DbSet<RefreshTokenEntity> RefreshTokens { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}