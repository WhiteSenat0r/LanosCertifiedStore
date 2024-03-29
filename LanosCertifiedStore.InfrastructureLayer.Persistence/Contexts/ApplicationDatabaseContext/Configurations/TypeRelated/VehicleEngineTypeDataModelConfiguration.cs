﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations.TypeRelated;

internal sealed class VehicleEngineTypeConfiguration : IEntityTypeConfiguration<VehicleEngineTypeDataModel>
{
    public void Configure(EntityTypeBuilder<VehicleEngineTypeDataModel> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);
        
        builder.HasMany(m => m.Vehicles)
            .WithOne(v => v.EngineType)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(m => m.Models)
            .WithMany(x => x.AvailableEngineTypes)
            .UsingEntity(join => join.ToTable("VehicleEngineTypesVehicleModels"));

        builder.HasIndex(p => p.Name).IsUnique();
    }
}