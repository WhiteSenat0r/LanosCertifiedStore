using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext.Configurations.TypeRelated;

internal sealed class VehicleTransmissionTypeConfiguration : IEntityTypeConfiguration<VehicleTransmissionType>
{
    public void Configure(EntityTypeBuilder<VehicleTransmissionType> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.HasMany(m => m.Vehicles)
            .WithOne(v => v.TransmissionType)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(m => m.Models)
            .WithMany(x => x.AvailableTransmissionTypes)
            .UsingEntity(join => join.ToTable("VehicleTransmissionTypesVehicleModels"));

        builder.HasIndex(p => p.Name).IsUnique();
        builder.ToTable("VehicleTransmissionTypes", DatabaseSchemas.VehiclesSchema);
    }
}