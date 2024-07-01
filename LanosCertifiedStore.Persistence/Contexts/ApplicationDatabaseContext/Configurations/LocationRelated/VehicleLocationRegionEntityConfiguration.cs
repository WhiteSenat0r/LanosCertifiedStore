using Domain.Entities.VehicleRelated.LocationRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations.LocationRelated;

internal sealed class VehicleLocationRegionConfiguration : IEntityTypeConfiguration<VehicleLocationRegion>
{
    public void Configure(EntityTypeBuilder<VehicleLocationRegion> builder)
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