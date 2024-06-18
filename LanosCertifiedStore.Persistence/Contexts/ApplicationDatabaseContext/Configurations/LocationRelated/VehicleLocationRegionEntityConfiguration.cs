using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities.VehicleRelated.LocationRelated;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations.LocationRelated;

internal sealed class VehicleLocationRegionConfiguration : IEntityTypeConfiguration<VehicleLocationRegionEntity>
{
    public void Configure(EntityTypeBuilder<VehicleLocationRegionEntity> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);
        
        builder.HasMany(m => m.RelatedAreas)
            .WithOne(l => l.LocationRegion)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(m => m.RelatedTowns)
            .WithOne(l => l.LocationRegion)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(p => p.Name).IsUnique();
    }
}