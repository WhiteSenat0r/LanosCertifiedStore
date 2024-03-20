using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations.TypeRelated;

internal sealed class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleTypeDataModel>
{
    public void Configure(EntityTypeBuilder<VehicleTypeDataModel> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(32);
        
        builder.HasMany(m => m.Vehicles)
            .WithOne(v => v.VehicleType)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(m => m.Models)
            .WithMany(x => x.AvailableTypes)
            .UsingEntity(join => join.ToTable("VehicleTypesVehicleModels"));
        
        builder.HasIndex(p => p.Name).IsUnique();
    }
}