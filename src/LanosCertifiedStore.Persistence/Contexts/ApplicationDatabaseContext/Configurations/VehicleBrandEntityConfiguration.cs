using Domain.Entities.VehicleRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations;

internal sealed class VehicleBrandEntityConfiguration : IEntityTypeConfiguration<VehicleBrand>
{
    public void Configure(EntityTypeBuilder<VehicleBrand> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.HasIndex(p => p.Name).IsUnique();
    }
}