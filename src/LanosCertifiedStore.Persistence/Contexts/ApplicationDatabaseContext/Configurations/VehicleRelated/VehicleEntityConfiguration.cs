using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext.Configurations.VehicleRelated;

internal sealed class VehicleEntityConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(2048);

        builder.Property(v => v.Vincode)
            .IsRequired()
            .HasMaxLength(17);

        builder.HasIndex(v => v.Vincode)
            .IsUnique();

        builder.ToTable(
            DatabaseConstants.Tables.Vehicles,
            DatabaseConstants.Schemas.VehiclesSchema);
    }
}