using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext.Configurations.LocationRelated;

internal sealed class VehicleLocationTownConfiguration : IEntityTypeConfiguration<VehicleLocationTown>
{
    public void Configure(EntityTypeBuilder<VehicleLocationTown> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.ToTable("VehicleLocationTowns", DatabaseSchemas.LocationsSchema);
    }
}