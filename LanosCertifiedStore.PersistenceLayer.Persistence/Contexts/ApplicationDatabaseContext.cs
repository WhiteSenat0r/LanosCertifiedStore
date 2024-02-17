using Microsoft.EntityFrameworkCore;
using Persistence.DataModels;

namespace Persistence.Contexts;

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
        modelBuilder.Entity<VehicleModelDataModel>()
            .HasOne(vm => vm.VehicleBrand)
            .WithMany(b => b.Models)
            .HasForeignKey(vm => vm.VehicleBrandId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}