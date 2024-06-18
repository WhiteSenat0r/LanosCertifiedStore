using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities.VehicleRelated;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations;

internal sealed class VehicleBrandEntityConfiguration : IEntityTypeConfiguration<VehicleBrandEntity>
{
    public void Configure(EntityTypeBuilder<VehicleBrandEntity> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.HasIndex(p => p.Name).IsUnique();
    }
}