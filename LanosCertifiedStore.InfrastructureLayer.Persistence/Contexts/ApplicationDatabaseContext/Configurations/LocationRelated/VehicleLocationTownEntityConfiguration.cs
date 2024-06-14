using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities.VehicleRelated.LocationRelated;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations.LocationRelated;

internal sealed class VehicleLocationTownConfiguration : IEntityTypeConfiguration<VehicleLocationTownEntity>
{
    public void Configure(EntityTypeBuilder<VehicleLocationTownEntity> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);
        
        builder.HasOne(m => m.LocationArea)
            .WithMany(l => l.RelatedTowns)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(m => m.LocationRegion)
            .WithMany(l => l.RelatedTowns)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(p => p.Name);
    }
}