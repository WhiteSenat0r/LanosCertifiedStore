using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext.Configurations.VehicleRelated;

internal sealed class VehicleImageEntityConfiguration : IEntityTypeConfiguration<VehicleImage>
{
    public void Configure(EntityTypeBuilder<VehicleImage> builder)
    {
        builder.HasKey(i => i.CloudImageId);
        builder.ToTable(DatabaseConstants.Tables.VehicleImages, DatabaseConstants.Schemas.VehiclesSchema);
    }
}