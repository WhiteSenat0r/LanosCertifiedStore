using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations.TypeRelated;

internal sealed class VehicleTransmissionTypeConfiguration : IEntityTypeConfiguration<VehicleTransmissionTypeDataModel>
{
    public void Configure(EntityTypeBuilder<VehicleTransmissionTypeDataModel> builder)
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
    }
}