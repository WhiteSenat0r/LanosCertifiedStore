using Application.Images;
using Application.LocationRegions;
using Application.LocationTowns;
using Application.VehicleBodyTypes;
using Application.VehicleBrands;
using Application.VehicleColors;
using Application.VehicleDrivetrainTypes;
using Application.VehicleEngineTypes;
using Application.VehicleModels;
using Application.VehicleTransmissionTypes;
using Application.VehicleTypes;
using LanosCertifiedStore.InfrastructureLayer.Services.Authentication;
using LanosCertifiedStore.InfrastructureLayer.Services.Images;
using LanosCertifiedStore.InfrastructureLayer.Services.Locations;
using LanosCertifiedStore.InfrastructureLayer.Services.Vehicles;
using Microsoft.Extensions.DependencyInjection;

namespace LanosCertifiedStore.InfrastructureLayer.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddExternalServices(this IServiceCollection services)
    {
        AddImageRelatedServices(services);
        AddVehicleRelatedServices(services);
        AddTypeRelatedServices(services);
        AddLocationRelatedServices(services);
        AddAuthenticationRelatedServices(services);

        return services;
    }

    private static void AddAuthenticationRelatedServices(IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddAuthentication().AddJwtBearer();
        services.AddHttpContextAccessor();
        services.ConfigureOptions<JwtBearerConfigureOptions>();
    }

    private static void AddImageRelatedServices(IServiceCollection services)
    {
        services.ConfigureOptions<CloudinaryConfigureOptions>();
        services.AddScoped<IImageService, ImageService>();
    }

    private static void AddVehicleRelatedServices(IServiceCollection services)
    {
        services.AddScoped<IVehicleBrandService, VehicleBrandService>();
        services.AddScoped<IVehicleColorService, VehicleColorService>();
        services.AddScoped<IVehicleModelService, VehicleModelService>();
    }

    private static void AddTypeRelatedServices(IServiceCollection services)
    {
        services.AddScoped<IVehicleTypeService, VehicleTypeService>();
        services.AddScoped<IVehicleBodyTypeService, VehicleBodyTypeService>();
        services.AddScoped<IVehicleDrivetrainTypeService, VehicleDrivetrainTypeService>();
        services.AddScoped<IVehicleTransmissionTypeService, VehicleTransmissionTypeService>();
        services.AddScoped<IVehicleEngineTypeService, VehicleEngineTypeService>();
    }

    private static void AddLocationRelatedServices(IServiceCollection services)
    {
        services.AddScoped<ILocationRegionService, LocationRegionService>();
        services.AddScoped<ILocationTownService, LocationTownService>();
    }
}