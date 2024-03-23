using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels.VehicleRelated.LocationRelated;

namespace Persistence.SeedingData;

public static class SeedData
{
    private const string SerializedLocationsFilePath =
        "LanosCertifiedStore.InfrastructureLayer.Persistence/" +
        "SeedingData/SerializedData/SerializedUkraineLocations.json";
    
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

        var locationsData = await GetLocationsData();

        var regions = SeedRegions.GetRegions(locationsData!.Keys);

        var areaRegionDictionary = GetAreaRegionDictionary(regions, locationsData);

        var areas = SeedAreas.GetAreas(areaRegionDictionary, regions);

        var towns = SeedTowns.GetTowns(regions, areas, locationsData);

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

    private static async Task<Dictionary<string, Dictionary<string, List<string>>>?> GetLocationsData()
    {
        var adjustedLocationsFilePath = $"{GetParentDirectory()}{SerializedLocationsFilePath}";
        
        var serializedLocationsData = await File.ReadAllTextAsync(adjustedLocationsFilePath);
        
        return JsonSerializer.Deserialize
            <Dictionary<string, Dictionary<string, List<string>>>>(serializedLocationsData);
    }

    private static Dictionary<string, string> GetAreaRegionDictionary(
        List<VehicleLocationRegionDataModel> regions,
        IReadOnlyDictionary<string, Dictionary<string, List<string>>> deserializedLocationsData)
    {
        var mappedAreas = new Dictionary<string, string>();

        foreach (var region in regions) 
            foreach (var area in deserializedLocationsData[region.Name]) 
                mappedAreas.Add(area.Key, region.Name);

        return mappedAreas;
    }

    private static string GetParentDirectory() =>
        Environment.CurrentDirectory.Replace('\\', '/')
            .Remove(Environment.CurrentDirectory.LastIndexOf('\\') + 1);
}