using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.SeedingData;

public static class SeedData
{
    public static async Task Seed(ApplicationDatabaseContext context)
    {
        if (!await context.VehicleTypes.AnyAsync())
            await context.VehicleTypes.AddRangeAsync(SeedTypes.GetTypes());

        if (!await context.VehiclesColors.AnyAsync())
            await context.VehiclesColors.AddRangeAsync(SeedColors.GetColors());

        if (!await context.VehicleDisplacements.AnyAsync())
            await context.VehicleDisplacements.AddRangeAsync(SeedDisplacements.GetDisplacements());

        if (context.ChangeTracker.HasChanges())
            await context.SaveChangesAsync();
    }
}