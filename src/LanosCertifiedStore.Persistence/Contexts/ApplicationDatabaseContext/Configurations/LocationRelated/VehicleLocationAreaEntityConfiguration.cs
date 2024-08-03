using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext.Configurations.LocationRelated;

internal sealed class VehicleLocationAreaConfiguration : IEntityTypeConfiguration<VehicleLocationArea>
{
    public void Configure(EntityTypeBuilder<VehicleLocationArea> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.HasIndex(p => p.Name);
        builder.ToTable(DatabaseConstants.Tables.VehicleLocationAreas, DatabaseConstants.Schemas.LocationsSchema);
    }
}