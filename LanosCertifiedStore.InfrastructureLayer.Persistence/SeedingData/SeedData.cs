using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;

namespace Persistence.SeedingData;

public static class SeedData
{
    public static async Task Seed(ApplicationDatabaseContext context)
    {
        // TODO
        // var types = SeedTypes.GetTypes();
        // if (!await context.VehicleTypes.AnyAsync())
        //     await context.VehicleTypes.AddRangeAsync(types);
        //
        // var colors = SeedColors.GetColors();
        // if (!await context.VehiclesColors.AnyAsync())
        //     await context.VehiclesColors.AddRangeAsync(colors);
        //
        // var brands = SeedBrands.GetBrands();
        // if (!await context.VehiclesBrands.AnyAsync())
        //     await context.VehiclesBrands.AddRangeAsync(brands);
        //
        // if (context.ChangeTracker.HasChanges())
        //     await context.SaveChangesAsync();
        //
        // var models = SeedModels.GetModels(brands, types);
        // if (!await context.VehicleModels.AnyAsync()) 
        //     await context.VehicleModels.AddRangeAsync(models);
        //
        // if (context.ChangeTracker.HasChanges())
        //     await context.SaveChangesAsync();
        //
        // var vehicles = SeedVehicles.GetVehicles(types, colors, brands, models);
        // if (!await context.Vehicles.AnyAsync())
        //     await context.Vehicles.AddRangeAsync(vehicles);
        //
        // var images = SeedImages.GetImages(vehicles);
        // if (!await context.VehicleImages.AnyAsync())
        //     await context.VehicleImages.AddRangeAsync(images);
        //
        // if (context.ChangeTracker.HasChanges())
        //     await context.SaveChangesAsync();
    }
}