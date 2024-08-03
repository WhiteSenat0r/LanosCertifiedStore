using System.Text.Json;
using LanosCertifiedStore.Domain.Entities.UserRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;
using LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;
using LanosCertifiedStore.Infrastructure.SeedingData.LocationRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LanosCertifiedStore.Infrastructure.SeedingData;

public sealed class SeedData
{
    private readonly KeycloakClient _keycloakClient;
    private readonly ApplicationDatabaseContext _context;
    private readonly string _serializedLocationsFilePath = string.Empty;

    public SeedData(string staticDataPath, ApplicationDatabaseContext context, IServiceProvider serviceProvider)
    {
        _context = context;
        _keycloakClient = serviceProvider.GetService<KeycloakClient>()!;
        if (string.IsNullOrEmpty(_serializedLocationsFilePath))
        {
            _serializedLocationsFilePath = $"{staticDataPath}/Data/Json/SerializedUkraineLocations.json";
        }
    }

    public async Task Seed()
    {
        await SeedVehicleTypes(_context);
        await SeedVehicleColors(_context);
        await SeedVehicleBodyTypes(_context);
        await SeedVehicleDrivetrainTypes(_context);
        await SeedVehicleEngineTypes(_context);
        await SeedVehicleTransmissionTypes(_context);
        await SeedBrands(_context);
        await SeedUsers();

        if (_context.ChangeTracker.HasChanges())
        {
            await _context.SaveChangesAsync();
        }

        await SeedLocations(_context);
        await SeedModels(_context);

        var vehicles = await SeedVehicles(_context);

        await SeedImages(_context, vehicles);

        if (_context.ChangeTracker.HasChanges())
        {
            await _context.SaveChangesAsync();
        }
    }

    private async Task SeedUsers()
    {
        var userRepresentations = new List<KeyValuePair<UserRepresentationWithPasswordAndId, UserRole>>
        {
            new(new(
                    Guid.NewGuid(),
                    "admin@lsc.com",
                    "admin@lsc.com",
                    true,
                    true,
                    new Dictionary<string, string>
                    {
                        { "phoneNumber", "+380671234567" }
                    },
                    "John",
                    "Doe",
                    [new CredentialRepresentation("password", "Adm!_pass2024", false)]),
                UserRole.Administrator),
            new(new(
                Guid.NewGuid(),
                "manager@lsc.com",
                "manager@lsc.com",
                true,
                true,
                new Dictionary<string, string>
                {
                    { "phoneNumber", "+380681234567" }
                },
                "Jane",
                "Doe",
                [new CredentialRepresentation("password", "Mng!_pass2024", false)]), UserRole.Manager),
            new(new(
                Guid.NewGuid(),
                "user@lsc.com",
                "user@lsc.com",
                true,
                true,
                new Dictionary<string, string>
                {
                    { "phoneNumber", "+380981234567" }
                },
                "Jack",
                "Doe",
                [new CredentialRepresentation("password", "Usr!_pass2024", false)]), UserRole.User)
        };

        if (!await _context.Set<User>().AnyAsync())
        {
            foreach (var userRepresentation in userRepresentations)
            {
                var id = await _keycloakClient.RegisterUserAsync(userRepresentation.Key);

                var createdUser = new User(Guid.Parse(id))
                {
                    UserRole = userRepresentation.Value
                };

                await _context.Set<User>().AddAsync(createdUser);
                _context.Attach(createdUser.UserRole);
            }
        }
    }

    private async Task SeedImages(ApplicationDatabaseContext context, List<Vehicle> vehicles)
    {
        var images = SeedingData.SeedImages.GetImages(vehicles);

        if (!await context.Set<VehicleImage>().AnyAsync())
        {
            await context.Set<VehicleImage>().AddRangeAsync(images);
        }
    }

    private async Task<List<Vehicle>> SeedVehicles(ApplicationDatabaseContext context)
    {
        var vehicles = SeedingData.SeedVehicles.GetVehicles(
            await context.Set<VehicleType>().AsNoTracking().ToListAsync(),
            await context.Set<VehicleColor>().AsNoTracking().ToListAsync(),
            await context.Set<VehicleBrand>().AsNoTracking().ToListAsync(),
            await context.Set<VehicleModel>().AsNoTracking().ToListAsync(),
            await context.Set<VehicleBodyType>().AsNoTracking().ToListAsync(),
            await context.Set<VehicleDrivetrainType>().AsNoTracking().ToListAsync(),
            await context.Set<VehicleEngineType>().AsNoTracking().ToListAsync(),
            await context.Set<VehicleTransmissionType>().AsNoTracking().ToListAsync(),
            await context.Set<VehicleLocationRegion>().AsNoTracking().ToListAsync(),
            await context.Set<VehicleLocationArea>().AsNoTracking().ToListAsync(),
            await context.Set<VehicleLocationTown>().AsNoTracking().ToListAsync(),
            await context.Set<User>().AsNoTracking().ToListAsync());

        if (await context.Set<Vehicle>().AnyAsync())
        {
            return vehicles;
        }

        foreach (var vehicle in vehicles)
        {
            await context.Set<Vehicle>().AddAsync(vehicle);

            await context.SaveChangesAsync();
        }

        return vehicles;
    }

    private async Task SeedModels(ApplicationDatabaseContext context)
    {
        var models = SeedingData.SeedModels.GetModels(
            await context.Set<VehicleBrand>().AsNoTracking().ToListAsync(),
            await context.Set<VehicleType>().AsNoTracking().ToListAsync(),
            await context.Set<VehicleEngineType>().AsNoTracking().ToListAsync(),
            await context.Set<VehicleBodyType>().AsNoTracking().ToListAsync(),
            await context.Set<VehicleDrivetrainType>().AsNoTracking().ToListAsync(),
            await context.Set<VehicleTransmissionType>().AsNoTracking().ToListAsync());

        if (!await context.Set<VehicleModel>().AnyAsync())
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

    private async Task SeedLocations(ApplicationDatabaseContext context)
    {
        var locationsData = await GetLocationsData();

        var regions = SeedRegions.GetRegions(locationsData!.Keys);

        if (!await context.Set<VehicleLocationRegion>().AnyAsync())
        {
            await context.Set<VehicleLocationRegion>().AddRangeAsync(regions);
        }

        var areaRegionDictionary = GetAreaRegionDictionary(regions, locationsData);

        var areas = SeedAreas.GetAreas(areaRegionDictionary, regions);

        if (!await context.Set<VehicleLocationArea>().AnyAsync())
        {
            await context.Set<VehicleLocationArea>().AddRangeAsync(areas);
        }

        var townTypes = new List<VehicleLocationTownType>
        {
            new("Місто"), new("Село"), new("Селище")
        };

        if (!await context.Set<VehicleLocationTownType>().AnyAsync())
        {
            await context.AddRangeAsync(townTypes);
        }

        var towns = SeedTowns.GetTowns(regions, areas, townTypes, locationsData);

        if (!await context.Set<VehicleLocationTown>().AnyAsync())
        {
            await context.AddRangeAsync(towns);
        }

        if (context.ChangeTracker.HasChanges())
        {
            await context.SaveChangesAsync();
        }

        context.ChangeTracker.Clear();
    }

    private async Task SeedBrands(ApplicationDatabaseContext context)
    {
        var brands = SeedingData.SeedBrands.GetBrands();

        if (!await context.Set<VehicleBrand>().AnyAsync())
        {
            await context.Set<VehicleBrand>().AddRangeAsync(brands);
        }
    }

    private async Task SeedVehicleTransmissionTypes(ApplicationDatabaseContext context)
    {
        var transmissionTypes = TypeRelated.SeedVehicleTransmissionTypes.GetVehicleTransmissionTypes();

        if (!await context.Set<VehicleTransmissionType>().AnyAsync())
        {
            await context.Set<VehicleTransmissionType>().AddRangeAsync(transmissionTypes);
        }
    }

    private async Task SeedVehicleEngineTypes(ApplicationDatabaseContext context)
    {
        var engineTypes = TypeRelated.SeedVehicleEngineTypes.GetVehicleEngineTypes();

        if (!await context.Set<VehicleEngineType>().AnyAsync())
        {
            await context.Set<VehicleEngineType>().AddRangeAsync(engineTypes);
        }
    }

    private async Task SeedVehicleDrivetrainTypes(ApplicationDatabaseContext context)
    {
        var drivetrainTypes = TypeRelated.SeedVehicleDrivetrainTypes.GetVehicleDrivetrainTypes();

        if (!await context.Set<VehicleDrivetrainType>().AnyAsync())
        {
            await context.Set<VehicleDrivetrainType>().AddRangeAsync(drivetrainTypes);
        }
    }

    private async Task SeedVehicleBodyTypes(ApplicationDatabaseContext context)
    {
        var bodyTypes = TypeRelated.SeedVehicleBodyTypes.GetVehicleBodyTypes();

        if (!await context.Set<VehicleBodyType>().AnyAsync())
        {
            await context.Set<VehicleBodyType>().AddRangeAsync(bodyTypes);
        }
    }

    private async Task SeedVehicleColors(ApplicationDatabaseContext context)
    {
        var colors = SeedColors.GetColors();

        if (!await context.Set<VehicleColor>().AnyAsync())
        {
            await context.Set<VehicleColor>().AddRangeAsync(colors);
        }
    }

    private async Task SeedVehicleTypes(ApplicationDatabaseContext context)
    {
        var types = TypeRelated.SeedVehicleTypes.GetVehicleTypes();

        if (!await context.Set<VehicleType>().AnyAsync())
        {
            await context.Set<VehicleType>().AddRangeAsync(types);
        }
    }

    private async Task<Dictionary<string, Dictionary<string, List<KeyValuePair<string, string>>>>?>
        GetLocationsData()
    {
        var serializedLocationsData = await File.ReadAllTextAsync(_serializedLocationsFilePath);

        return JsonSerializer.Deserialize
            <Dictionary<string, Dictionary<string, List<KeyValuePair<string, string>>>>>(serializedLocationsData);
    }

    private Dictionary<string, string> GetAreaRegionDictionary(
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