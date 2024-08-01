using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext.Configurations.VehicleRelated;

internal sealed class VehicleColorEntityConfiguration : IEntityTypeConfiguration<VehicleColor>
{
    public void Configure(EntityTypeBuilder<VehicleColor> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(32);

        builder.Property(p => p.HexValue)
            .IsRequired()
            .HasMaxLength(12);
        
        builder.HasMany(m => m.Vehicles)
            .WithOne(v => v.Color)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(p => p.Name).IsUnique();
        builder.ToTable("VehicleColors", DatabaseSchemas.VehiclesSchema);
    }
}