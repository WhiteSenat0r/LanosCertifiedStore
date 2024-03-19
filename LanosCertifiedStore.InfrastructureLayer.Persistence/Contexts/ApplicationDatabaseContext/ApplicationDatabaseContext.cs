using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels.IdentityRelated;
using Persistence.DataModels.UserRelated;
using Persistence.DataModels.VehicleRelated;
using Persistence.DataModels.VehicleRelated.LocationRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.Contexts.ApplicationDatabaseContext;

public sealed class ApplicationDatabaseContext(
    DbContextOptions<ApplicationDatabaseContext> options) : DbContext(options)
{
    internal DbSet<VehicleDataModel> Vehicles { get; set; } = null!;
    internal DbSet<VehicleBrandDataModel> VehiclesBrands { get; set; } = null!;
    internal DbSet<VehicleColorDataModel> VehiclesColors { get; set; } = null!;
    internal DbSet<VehicleModelDataModel> VehicleModels { get; set; } = null!;
    internal DbSet<VehiclePriceDataModel> VehiclePrices { get; set; } = null!;
    internal DbSet<VehicleTypeDataModel> VehicleTypes { get; set; } = null!;
    internal DbSet<VehicleBodyTypeDataModel> VehicleBodyTypes { get; set; } = null!;
    internal DbSet<VehicleEngineTypeDataModel> VehicleEngineTypes { get; set; } = null!;
    internal DbSet<VehicleDrivetrainTypeDataModel> VehicleDrivetrainTypes { get; set; } = null!;
    internal DbSet<VehicleTransmissionTypeDataModel> VehicleTransmissionTypes { get; set; } = null!;
    internal DbSet<VehicleLocationTownDataModel> VehicleLocationTowns { get; set; } = null!;
    internal DbSet<VehicleLocationRegionDataModel> VehicleLocationRegions { get; set; } = null!;
    internal DbSet<VehicleImageDataModel> VehicleImages { get; set; } = null!;
    internal DbSet<UserDataModel> Users { get; set; } = null!;
    internal DbSet<UserRoleDataModel> Roles { get; set; } = null!;
    internal DbSet<RefreshTokenDataModel> RefreshTokens { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}