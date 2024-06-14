using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities.VehicleRelated.TypeRelated;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations.TypeRelated;

internal sealed class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleTypeEntity>
{
    public void Configure(EntityTypeBuilder<VehicleTypeEntity> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);
        
        builder.HasMany(m => m.Vehicles)
            .WithOne(v => v.VehicleType)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(m => m.Models)
            .WithOne(x => x.VehicleType)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasIndex(p => p.Name).IsUnique();
    }
}