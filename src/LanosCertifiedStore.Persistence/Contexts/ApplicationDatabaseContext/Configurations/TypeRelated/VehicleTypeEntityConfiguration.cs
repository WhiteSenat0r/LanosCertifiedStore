using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext.Configurations.TypeRelated;

internal sealed class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleType>
{
    public void Configure(EntityTypeBuilder<VehicleType> builder)
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
        builder.ToTable("VehicleTypes", DatabaseSchemas.VehiclesSchema);

    }
}