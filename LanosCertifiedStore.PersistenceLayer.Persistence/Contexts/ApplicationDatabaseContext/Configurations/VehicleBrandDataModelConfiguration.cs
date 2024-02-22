using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataModels.VehicleRelated;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations;

internal sealed class VehicleBrandDataModelConfiguration : IEntityTypeConfiguration<VehicleBrandDataModel>
{
    public void Configure(EntityTypeBuilder<VehicleBrandDataModel> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.HasIndex(p => p.Name).IsUnique();
    }
}