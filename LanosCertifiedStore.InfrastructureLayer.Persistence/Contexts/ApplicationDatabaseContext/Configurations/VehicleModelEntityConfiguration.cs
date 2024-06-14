using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities.VehicleRelated;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations;

internal sealed class VehicleModelConfiguration : IEntityTypeConfiguration<VehicleModelEntity>
{
    public void Configure(EntityTypeBuilder<VehicleModelEntity> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.HasOne(vm => vm.VehicleBrand)
            .WithMany(b => b.Models)
            .HasForeignKey(vm => vm.VehicleBrandId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(p => p.Name).IsUnique();
    }
}