﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataModels.VehicleRelated.LocationRelated;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations.LocationRelated;

internal sealed class VehicleLocationAreaConfiguration : IEntityTypeConfiguration<VehicleLocationAreaDataModel>
{
    public void Configure(EntityTypeBuilder<VehicleLocationAreaDataModel> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);
        
        builder.HasOne(m => m.LocationRegion)
            .WithMany(l => l.RelatedAreas)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(m => m.RelatedTowns)
            .WithOne(l => l.LocationArea)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(p => p.Name).IsUnique();
    }
}