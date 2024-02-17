using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataModels;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations;

internal sealed class VehicleTyperConfiguration : IEntityTypeConfiguration<VehicleTypeDataModel>
{
    public void Configure(EntityTypeBuilder<VehicleTypeDataModel> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);
        
        builder.HasMany(m => m.Vehicles)
            .WithOne(v => v.Type)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(p => p.Name).IsUnique();
    }
}