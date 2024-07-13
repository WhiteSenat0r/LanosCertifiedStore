using System.Text.Json;
using Domain.Entities.VehicleRelated;
using Domain.Entities.VehicleRelated.LocationRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.SeedingData.LocationRelated;

namespace Persistence.SeedingData;

public static class SeedData
{
    private static string _serializedLocationsFilePath = "Data/Json/SerializedUkraineLocations.json";

    public static async Task Seed(ApplicationDatabaseContext context, string staticDataPath)
    {
        _serializedLocationsFilePath = string.Join('/', [staticDataPath, _serializedLocationsFilePath]);
        
        await SeedVehicleTypes(context);
        await SeedVehicleColors(context);
        await SeedVehicleBodyTypes(context);
        await SeedVehicleDrivetrainTypes(context);
        await SeedVehicleEngineTypes(context);
        await SeedVehicleTransmissionTypes(context);
        await SeedBrands(context);

        if (context.ChangeTracker.HasChanges())
        {
            await context.SaveChangesAsync();
        }

        await SeedLocations(context);
        await SeedModels(context);

        var vehicles = await SeedVehicles(context);

        await SeedImages(context, vehicles);

        if (context.ChangeTracker.HasChanges())
        {
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedImages(ApplicationDatabaseContext context, List<Vehicle> vehicles)
    {
        var images = SeedingData.SeedImages.GetImages(vehicles);

        if (!await context.VehicleImages.AnyAsync())
        {
            await context.VehicleImages.AddRangeAsync(images);
        }
    }

    private static async Task<List<Vehicle>> SeedVehicles(ApplicationDatabaseContext context)
    {
        var vehicles = SeedingData.SeedVehicles.GetVehicles(
            await context.VehicleTypes.AsNoTracking().ToListAsync(),
            await context.VehicleColors.AsNoTracking().ToListAsync(),
            await context.VehiclesBrands.AsNoTracking().ToListAsync(),
            await context.VehicleModels.AsNoTracking().ToListAsync(),
            await context.VehicleBodyTypes.AsNoTracking().ToListAsync(),
            await context.VehicleDrivetrainTypes.AsNoTracking().ToListAsync(),
            await context.VehicleEngineTypes.AsNoTracking().ToListAsync(),
            await context.VehicleTransmissionTypes.AsNoTracking().ToListAsync(),
            await context.VehicleLocationRegions.AsNoTracking().ToListAsync(),
            await context.VehicleLocationAreas.AsNoTracking().ToListAsync(),
            await context.VehicleLocationTowns.AsNoTracking().ToListAsync());

        if (await context.Vehicles.AnyAsync())
        {
            return vehicles;
        }

        foreach (var vehicle in vehicles)
        {
            await context.Vehicles.AddAsync(vehicle);

            await context.SaveChangesAsync();
        }

        return vehicles;
    }

    private static async Task SeedModels(ApplicationDatabaseContext context)
    {
        var models = SeedingData.SeedModels.GetModels(
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
                var insertedModel = new VehicleModel
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

                await context.SaveChangesAsync();
            }
        }
    }

    private static async Task SeedLocations(ApplicationDatabaseContext context)
    {
        var locationsData = await GetLocationsData();

        var regions = SeedRegions.GetRegions(locationsData!.Keys);

        if (!await context.VehicleLocationRegions.AnyAsync())
        {
            await context.VehicleLocationRegions.AddRangeAsync(regions);
        }

        var areaRegionDictionary = GetAreaRegionDictionary(regions, locationsData);

        var areas = SeedAreas.GetAreas(areaRegionDictionary, regions);

        if (!await context.VehicleLocationAreas.AnyAsync())
        {
            await context.VehicleLocationAreas.AddRangeAsync(areas);
        }

        var townTypes = new List<VehicleLocationTownType>
        {
            new("Місто"), new("Село"), new("Селище")
        };

        if (!await context.VehicleLocationTownTypes.AnyAsync())
        {
            await context.AddRangeAsync(townTypes);
        }

        var towns = SeedTowns.GetTowns(regions, areas, townTypes, locationsData);

        if (!await context.VehicleLocationTowns.AnyAsync())
        {
            await context.AddRangeAsync(towns);
        }

        if (context.ChangeTracker.HasChanges())
        {
            await context.SaveChangesAsync();
        }
        
        context.ChangeTracker.Clear();
    }

    private static async Task SeedBrands(ApplicationDatabaseContext context)
    {
        var brands = SeedingData.SeedBrands.GetBrands();

        if (!await context.VehiclesBrands.AnyAsync())
        {
            await context.VehiclesBrands.AddRangeAsync(brands);
        }
    }

    private static async Task SeedVehicleTransmissionTypes(ApplicationDatabaseContext context)
    {
        var transmissionTypes = TypeRelated.SeedVehicleTransmissionTypes.GetVehicleTransmissionTypes();

        if (!await context.VehicleTransmissionTypes.AnyAsync())
        {
            await context.VehicleTransmissionTypes.AddRangeAsync(transmissionTypes);
        }
    }

    private static async Task SeedVehicleEngineTypes(ApplicationDatabaseContext context)
    {
        var engineTypes = TypeRelated.SeedVehicleEngineTypes.GetVehicleEngineTypes();

        if (!await context.VehicleEngineTypes.AnyAsync())
        {
            await context.VehicleEngineTypes.AddRangeAsync(engineTypes);
        }
    }

    private static async Task SeedVehicleDrivetrainTypes(ApplicationDatabaseContext context)
    {
        var drivetrainTypes = TypeRelated.SeedVehicleDrivetrainTypes.GetVehicleDrivetrainTypes();

        if (!await context.VehicleDrivetrainTypes.AnyAsync())
        {
            await context.VehicleDrivetrainTypes.AddRangeAsync(drivetrainTypes);
        }
    }

    private static async Task SeedVehicleBodyTypes(ApplicationDatabaseContext context)
    {
        var bodyTypes = TypeRelated.SeedVehicleBodyTypes.GetVehicleBodyTypes();

        if (!await context.VehicleBodyTypes.AnyAsync())
        {
            await context.VehicleBodyTypes.AddRangeAsync(bodyTypes);
        }
    }

    private static async Task SeedVehicleColors(ApplicationDatabaseContext context)
    {
        var colors = SeedColors.GetColors();

        if (!await context.VehicleColors.AnyAsync())
        {
            await context.VehicleColors.AddRangeAsync(colors);
        }
    }

    private static async Task SeedVehicleTypes(ApplicationDatabaseContext context)
    {
        var types = TypeRelated.SeedVehicleTypes.GetVehicleTypes();

        if (!await context.VehicleTypes.AnyAsync())
        {
            await context.VehicleTypes.AddRangeAsync(types);
        }
    }

    private static async Task<Dictionary<string, Dictionary<string, List<KeyValuePair<string, string>>>>?>
        GetLocationsData()
    {
        var serializedLocationsData = await File.ReadAllTextAsync(_serializedLocationsFilePath);

        return JsonSerializer.Deserialize
            <Dictionary<string, Dictionary<string, List<KeyValuePair<string, string>>>>>(serializedLocationsData);
    }

    private static Dictionary<string, string> GetAreaRegionDictionary(
        List<VehicleLocationRegion> regions,
        Dictionary<string, Dictionary<string, List<KeyValuePair<string, string>>>> deserializedLocationsData)
    {
        var mappedAreas = new Dictionary<string, string>();

        foreach (var region in regions)
        foreach (var area in deserializedLocationsData[region.Name])
            mappedAreas.Add(area.Key, region.Name);

        return mappedAreas;
    }
}