using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public sealed class ApplicationDatabaseContext(
    DbContextOptions<ApplicationDatabaseContext> options) : DbContext(options)
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleBrand> VehiclesBrands { get; set; }
    public DbSet<VehicleColor> VehiclesColors { get; set; }
    public DbSet<VehicleDisplacement> VehicleDisplacements { get; set; }
    public DbSet<VehicleModel> VehicleModels { get; set; }
    public DbSet<VehiclePrice> VehiclePrices { get; set; }
    public DbSet<VehicleType> VehicleTypes { get; set; }
}