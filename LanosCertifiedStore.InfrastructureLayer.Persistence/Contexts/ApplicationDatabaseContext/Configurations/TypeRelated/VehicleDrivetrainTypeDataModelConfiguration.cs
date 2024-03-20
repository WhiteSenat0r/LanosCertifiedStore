using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations.TypeRelated;

internal sealed class VehicleDrivetrainTypeConfiguration : IEntityTypeConfiguration<VehicleDrivetrainTypeDataModel>
{
    public void Configure(EntityTypeBuilder<VehicleDrivetrainTypeDataModel> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(32);
        
        builder.HasMany(m => m.Vehicles)
            .WithOne(v => v.DrivetrainType)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(m => m.Models)
            .WithMany(x => x.AvailableDrivetrainTypes)
            .UsingEntity(join => join.ToTable("VehicleDrivetrainTypesVehicleModels"));

        builder.HasIndex(p => p.Name).IsUnique();
    }
}