using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities.VehicleRelated;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations;

internal sealed class VehiclePriceEntityConfiguration : IEntityTypeConfiguration<VehiclePriceEntity>
{
    public void Configure(EntityTypeBuilder<VehiclePriceEntity> builder)
    {
        builder.Property(p => p.Value)
            .HasColumnType("decimal(10,2)")
            .IsRequired();
    }
}