using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext.Configurations.TypeRelated;

internal sealed class VehicleBodyTypeConfiguration : IEntityTypeConfiguration<VehicleBodyType>
{
    public void Configure(EntityTypeBuilder<VehicleBodyType> builder)
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
        builder.ToTable(DatabaseConstants.Tables.VehicleBodyTypes, DatabaseConstants.Schemas.VehiclesSchema);
    }
}