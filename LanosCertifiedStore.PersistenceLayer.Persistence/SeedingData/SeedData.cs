using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;

namespace Persistence.SeedingData;

public static class SeedData
{
    public static async Task Seed(ApplicationDatabaseContext context)
    {
        var types = SeedTypes.GetTypes();
        if (!await context.VehicleTypes.AnyAsync())
            await context.VehicleTypes.AddRangeAsync(types);

        var colors = SeedColors.GetColors();
        if (!await context.VehiclesColors.AnyAsync())
            await context.VehiclesColors.AddRangeAsync(colors);
        
        var brands = SeedBrands.GetBrands();
        if (!await context.VehiclesBrands.AnyAsync())
            await context.VehiclesBrands.AddRangeAsync(brands);
        
        if (context.ChangeTracker.HasChanges())
            await context.SaveChangesAsync();

        var models = SeedModels.GetModels(brands);
        if (!await context.VehicleModels.AnyAsync()) 
            await context.VehicleModels.AddRangeAsync(models);
        
        if (context.ChangeTracker.HasChanges())
            await context.SaveChangesAsync();
        
        // TODO Imlpement new seeding
        //
        // var vehicles = SeedVehicles.GetVehicles(types, colors, brands, models);
        // if (!await context.Vehicles.AnyAsync())
        //     await context.Vehicles.AddRangeAsync(vehicles);
        //
        // if (context.ChangeTracker.HasChanges())
        //     await context.SaveChangesAsync();
    }
}