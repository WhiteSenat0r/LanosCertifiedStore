using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels;

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
    internal DbSet<VehicleImageDataModel> VehicleImages { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}