using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataModels;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations;

internal sealed class VehicleColorDataModelConfiguration : IEntityTypeConfiguration<VehicleColorDataModel>
{
    public void Configure(EntityTypeBuilder<VehicleColorDataModel> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(32);

        builder.Property(p => p.HexValue)
            .IsRequired()
            .HasMaxLength(12);
        
        builder.HasMany(m => m.Vehicles)
            .WithOne(v => v.Color)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(p => p.Name).IsUnique();
    }
}