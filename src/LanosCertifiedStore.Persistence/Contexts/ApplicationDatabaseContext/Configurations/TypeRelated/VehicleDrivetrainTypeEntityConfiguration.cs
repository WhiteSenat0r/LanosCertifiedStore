using Domain.Entities.VehicleRelated.TypeRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations.TypeRelated;

internal sealed class VehicleDrivetrainTypeConfiguration : IEntityTypeConfiguration<VehicleDrivetrainType>
{
    public void Configure(EntityTypeBuilder<VehicleDrivetrainType> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.HasMany(m => m.Vehicles)
            .WithOne(v => v.DrivetrainType)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(m => m.Models)
            .WithMany(x => x.AvailableDrivetrainTypes)
            .UsingEntity(join => join.ToTable("VehicleDrivetrainTypesVehicleModels"));

        builder.HasIndex(p => p.Name).IsUnique();
        builder.ToTable("VehicleDrivetrainTypes", DatabaseSchemas.VehiclesSchema);
    }
}