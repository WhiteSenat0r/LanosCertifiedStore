using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext.Configurations.LocationRelated;

internal sealed class VehicleLocationRegionConfiguration : IEntityTypeConfiguration<VehicleLocationRegion>
{
    public void Configure(EntityTypeBuilder<VehicleLocationRegion> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.HasIndex(p => p.Name);
        builder.ToTable("VehicleLocationRegions", DatabaseSchemas.LocationsSchema);
    }
}