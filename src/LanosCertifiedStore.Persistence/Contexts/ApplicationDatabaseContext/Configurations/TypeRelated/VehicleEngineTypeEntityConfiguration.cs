using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext.Configurations.TypeRelated;

internal sealed class VehicleEngineTypeConfiguration : IEntityTypeConfiguration<VehicleEngineType>
{
    public void Configure(EntityTypeBuilder<VehicleEngineType> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);
        
        builder.HasMany(m => m.Vehicles)
            .WithOne(v => v.EngineType)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(m => m.Models)
            .WithMany(x => x.AvailableEngineTypes)
            .UsingEntity(join => join.ToTable("VehicleEngineTypesVehicleModels"));

        builder.HasIndex(p => p.Name).IsUnique();
        builder.ToTable(DatabaseConstants.Tables.VehicleEngineTypes, DatabaseConstants.Schemas.VehiclesSchema);

    }
}