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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LanosCertifiedStore.InfrastructureLayer.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddExternalServices(this IServiceCollection services, IConfiguration config)
    {
        AddCloudinaryConfiguration(services, config);

        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<IVehicleBrandService, VehicleBrandService>();
        services.AddScoped<IVehicleColorService, VehicleColorService>();
        services.AddScoped<IVehicleTypeService, VehicleTypeService>();
        services.AddScoped<IVehicleBodyTypeService, VehicleBodyTypeService>();
        services.AddScoped<IVehicleDrivetrainTypeService, VehicleDrivetrainTypeService>();
        services.AddScoped<IVehicleTransmissionTypeService, VehicleTransmissionTypeService>();
        services.AddScoped<IVehicleEngineTypeService, VehicleEngineTypeService>();
        services.AddScoped<ILocationRegionService, LocationRegionService>();
        services.AddScoped<ILocationTownService, LocationTownService>();
        services.AddScoped<IVehicleModelService, VehicleModelService>();

        services
            .AddAuthentication()
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme);

        services.Configure<AuthenticationOptions>(config.GetSection("Authentication"));
        services.ConfigureOptions<JwtBearerOptionsSetup>();

        return services;
    }

    private static void AddCloudinaryConfiguration(IServiceCollection services, IConfiguration config)
    {
        services.Configure<CloudinarySettings>(cloudinarySettings =>
        {
            cloudinarySettings.ApiKey = config.GetSection("Cloudinary")["ApiKey"]!;
            cloudinarySettings.ApiSecret = config.GetSection("Cloudinary")["ApiSecret"]!;
            cloudinarySettings.CloudName = config.GetSection("Cloudinary")["CloudName"]!;
        });
    }
}