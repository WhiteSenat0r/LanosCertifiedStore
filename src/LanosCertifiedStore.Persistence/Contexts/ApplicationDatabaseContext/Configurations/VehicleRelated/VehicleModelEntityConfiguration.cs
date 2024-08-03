using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext.Configurations.VehicleRelated;

internal sealed class VehicleModelConfiguration : IEntityTypeConfiguration<VehicleModel>
{
    public void Configure(EntityTypeBuilder<VehicleModel> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.HasOne(vm => vm.VehicleBrand)
            .WithMany(b => b.Models)
            .HasForeignKey(vm => vm.VehicleBrandId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(p => new { p.Name, p.VehicleBrandId }).IsUnique();
        builder.ToTable(DatabaseConstants.Tables.VehicleModels, DatabaseConstants.Schemas.VehiclesSchema);
    }
}