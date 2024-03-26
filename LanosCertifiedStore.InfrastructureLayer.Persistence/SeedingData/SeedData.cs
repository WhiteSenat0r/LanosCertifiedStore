using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels.VehicleRelated;
using Persistence.DataModels.VehicleRelated.LocationRelated;
using Persistence.SeedingData.LocationRelated;
using Persistence.SeedingData.TypeRelated;

namespace Persistence.SeedingData;

public static class SeedData
{
    private const string SerializedLocationsFilePath =
        "LanosCertifiedStore.InfrastructureLayer.Persistence/" +
        "SeedingData/SerializedData/SerializedUkraineLocations.json";
    
    public static async Task Seed(ApplicationDatabaseContext context)
    {
        var types = TypeRelated.SeedVehicleTypes.GetVehicleTypes();
        if (!await context.VehicleTypes.AnyAsync())
            await context.VehicleTypes.AddRangeAsync(types);
        
        var colors = SeedColors.GetColors();
        if (!await context.VehiclesColors.AnyAsync())
            await context.VehiclesColors.AddRangeAsync(colors);
        
        var bodyTypes = SeedVehicleBodyTypes.GetVehicleBodyTypes();
        if (!await context.VehicleBodyTypes.AnyAsync())
            await context.VehicleBodyTypes.AddRangeAsync(bodyTypes);

        var drivetrainTypes = SeedVehicleDrivetrainTypes.GetVehicleDrivetrainTypes();
        if (!await context.VehicleDrivetrainTypes.AnyAsync())
            await context.VehicleDrivetrainTypes.AddRangeAsync(drivetrainTypes);

        var engineTypes = SeedVehicleEngineTypes.GetVehicleEngineTypes();
        if (!await context.VehicleEngineTypes.AnyAsync())
            await context.VehicleEngineTypes.AddRangeAsync(engineTypes);
        
        var transmissionTypes = SeedVehicleTransmissionTypes.GetVehicleTransmissionTypes();
        if (!await context.VehicleTransmissionTypes.AnyAsync())
            await context.VehicleTransmissionTypes.AddRangeAsync(transmissionTypes);
        
        var brands = SeedBrands.GetBrands();
        if (!await context.VehiclesBrands.AnyAsync())
            await context.VehiclesBrands.AddRangeAsync(brands);

        if (context.ChangeTracker.HasChanges())
            await context.SaveChangesAsync();
        
        var locationsData = await GetLocationsData();

        var regions = SeedRegions.GetRegions(locationsData!.Keys);
        if (!await context.VehicleLocationRegions.AnyAsync())
            await context.VehicleLocationRegions.AddRangeAsync(regions);

        var areaRegionDictionary = GetAreaRegionDictionary(regions, locationsData);
        var areas = SeedAreas.GetAreas(areaRegionDictionary, regions);
        if (!await context.VehicleLocationAreas.AnyAsync())
            await context.VehicleLocationAreas.AddRangeAsync(areas);

        var towns = SeedTowns.GetTowns(regions, areas, locationsData);
        if (!await context.VehicleLocationTowns.AnyAsync())
            await context.VehicleLocationTowns.AddRangeAsync(towns);

        if (context.ChangeTracker.HasChanges())
            await context.SaveChangesAsync();
        
        context.ChangeTracker.Clear();
        
        var models = SeedModels.GetModels(
            await context.VehiclesBrands.AsNoTracking().ToListAsync(),
            await context.VehicleTypes.AsNoTracking().ToListAsync(),
            await context.VehicleEngineTypes.AsNoTracking().ToListAsync(),
            await context.VehicleBodyTypes.AsNoTracking().ToListAsync(),
            await context.VehicleDrivetrainTypes.AsNoTracking().ToListAsync(),
            await context.VehicleTransmissionTypes.AsNoTracking().ToListAsync());
        if (!await context.VehicleModels.AnyAsync())
        {
            foreach (var model in models)
            {
                var insertedModel = new VehicleModelDataModel()
                {
                    Name = model.Name,
                    MinimalProductionYear = model.MinimalProductionYear,
                    VehicleTypeId = model.VehicleTypeId,
                    VehicleBrandId = model.VehicleBrandId
                };

                await context.AddAsync(insertedModel);
                
                await context.SaveChangesAsync();

                insertedModel.AvailableBodyTypes = model.AvailableBodyTypes;
                insertedModel.AvailableEngineTypes = model.AvailableEngineTypes;
                insertedModel.AvailableTransmissionTypes = model.AvailableTransmissionTypes;
                insertedModel.AvailableDrivetrainTypes = model.AvailableDrivetrainTypes;

                context.Update(insertedModel);
            }
        }
        
        var vehicles = SeedVehicles.GetVehicles(
            await context.VehicleTypes.AsNoTracking().ToListAsync(),
            await context.VehiclesColors.AsNoTracking().ToListAsync(),
            await context.VehiclesBrands.AsNoTracking().ToListAsync(),
            await context.VehicleModels.AsNoTracking().ToListAsync(),
            await context.VehicleBodyTypes.AsNoTracking().ToListAsync(),
            await context.VehicleDrivetrainTypes.AsNoTracking().ToListAsync(),
            await context.VehicleEngineTypes.AsNoTracking().ToListAsync(),
            await context.VehicleTransmissionTypes.AsNoTracking().ToListAsync(),
            await context.VehicleLocationRegions.AsNoTracking().ToListAsync(),
            await context.VehicleLocationAreas.AsNoTracking().ToListAsync(),
            await context.VehicleLocationTowns.AsNoTracking().ToListAsync());
        if (!await context.Vehicles.AnyAsync())
        {
            foreach (var vehicle in vehicles)
            {
                await context.Vehicles.AddAsync(vehicle);
                
                await context.SaveChangesAsync();
            }
        }
            
        var images = SeedImages.GetImages(vehicles);
        if (!await context.VehicleImages.AnyAsync())
            await context.VehicleImages.AddRangeAsync(images);
        
        if (context.ChangeTracker.HasChanges())
            await context.SaveChangesAsync();
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