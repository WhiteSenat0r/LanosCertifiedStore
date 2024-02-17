using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataModels;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations;

internal sealed class VehiclePriceDataModelConfiguration : IEntityTypeConfiguration<VehiclePriceDataModel>
{
    public void Configure(EntityTypeBuilder<VehiclePriceDataModel> builder)
    {
        builder.Property(p => p.Value)
            .HasColumnType("decimal(10,2)")
            .IsRequired();
    }
}