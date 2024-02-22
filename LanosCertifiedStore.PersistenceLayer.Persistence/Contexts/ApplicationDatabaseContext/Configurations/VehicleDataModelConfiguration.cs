using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataModels.VehicleRelated;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations;

internal sealed class VehicleDataModelConfiguration : IEntityTypeConfiguration<VehicleDataModel>
{
    public void Configure(EntityTypeBuilder<VehicleDataModel> builder)
    {
        builder.Property(x => x.Description).IsRequired().HasMaxLength(2048);
    }
}