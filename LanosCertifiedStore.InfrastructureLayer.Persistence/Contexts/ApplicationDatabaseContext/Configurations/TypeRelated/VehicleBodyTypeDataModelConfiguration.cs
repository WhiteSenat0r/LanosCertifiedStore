using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations.TypeRelated;

internal sealed class VehicleBodyTypeConfiguration : IEntityTypeConfiguration<VehicleBodyTypeDataModel>
{
    public void Configure(EntityTypeBuilder<VehicleBodyTypeDataModel> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);
        
        builder.HasMany(m => m.Vehicles)
            .WithOne(v => v.BodyType)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(m => m.Models)
            .WithMany(x => x.AvailableBodyTypes)
            .UsingEntity(join => join.ToTable("VehicleBodyTypesVehicleModels"));

        builder.HasIndex(p => p.Name).IsUnique();
    }
}