using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities.VehicleRelated;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations;

internal sealed class VehicleEntityConfiguration : IEntityTypeConfiguration<VehicleEntity>
{
    public void Configure(EntityTypeBuilder<VehicleEntity> builder)
    {
        builder.Property(x => x.Description).IsRequired().HasMaxLength(2048);
    }
}