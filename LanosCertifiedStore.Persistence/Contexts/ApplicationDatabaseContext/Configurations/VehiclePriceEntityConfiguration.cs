using Domain.Entities.VehicleRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations;

internal sealed class VehiclePriceEntityConfiguration : IEntityTypeConfiguration<VehiclePrice>
{
    public void Configure(EntityTypeBuilder<VehiclePrice> builder)
    {
        builder.Property(p => p.Value)
            .HasColumnType("decimal(10,2)")
            .IsRequired();
    }
}