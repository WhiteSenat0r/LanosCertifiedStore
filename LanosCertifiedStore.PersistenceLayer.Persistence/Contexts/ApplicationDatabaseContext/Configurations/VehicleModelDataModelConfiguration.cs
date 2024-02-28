using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataModels.VehicleRelated;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations;

internal sealed class VehicleModelConfiguration : IEntityTypeConfiguration<VehicleModelDataModel>
{
    public void Configure(EntityTypeBuilder<VehicleModelDataModel> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);

        // builder.Property(p => p.AvailableTypes)
        //     .IsRequired();

        builder.HasOne(vm => vm.VehicleBrand)
            .WithMany(b => b.Models)
            .HasForeignKey(vm => vm.VehicleBrandId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(p => p.Name).IsUnique();
    }
}