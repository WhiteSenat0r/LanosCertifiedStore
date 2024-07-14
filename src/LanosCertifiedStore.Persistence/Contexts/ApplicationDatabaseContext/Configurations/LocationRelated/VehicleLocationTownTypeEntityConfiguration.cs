using Domain.Entities.VehicleRelated.LocationRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations.LocationRelated;

internal sealed class VehicleLocationTownTypeConfiguration : IEntityTypeConfiguration<VehicleLocationTownType>
{
    public void Configure(EntityTypeBuilder<VehicleLocationTownType> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.HasIndex(p => p.Name);
        builder.ToTable("VehicleLocationTownTypes", DatabaseSchemas.LocationsSchema);
    }
}