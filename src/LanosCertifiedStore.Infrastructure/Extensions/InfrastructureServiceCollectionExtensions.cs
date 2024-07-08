using Application.Identity.ServicesContracts;
using Application.Images;
using Application.LocationRegions;
using Application.LocationTowns;
using Application.VehicleBodyTypes;
using Application.VehicleBrands;
using Application.VehicleColors;
using Application.VehicleDrivetrainTypes;
using Application.VehicleEngineTypes;
using Application.VehicleTransmissionTypes;
using Application.VehicleTypes;
using LanosCertifiedStore.InfrastructureLayer.Services.Services;
using LanosCertifiedStore.InfrastructureLayer.Services.Services.IdentityRelated;
using LanosCertifiedStore.InfrastructureLayer.Services.Services.IdentityRelated.JwtTokenRelated;
using LanosCertifiedStore.InfrastructureLayer.Services.Services.ImagesRelated;
using LanosCertifiedStore.InfrastructureLayer.Services.Services.ImagesRelated.Common;
using LanosCertifiedStore.InfrastructureLayer.Services.Services.LocationRelated;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Extensions;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddExternalServices(this IServiceCollection services, IConfiguration config)
    {
        AddCloudinaryConfiguration(services, config);
        AddJwtOptionsConfiguration(services, config);

        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IVehicleBrandService, VehicleBrandService>();
        services.AddScoped<IVehicleColorService, VehicleColorService>();
        services.AddScoped<IVehicleTypeService, VehicleTypeService>();
        services.AddScoped<IVehicleBodyTypeService, VehicleBodyTypeService>();
        services.AddScoped<IVehicleDrivetrainTypeService, VehicleDrivetrainTypeService>();
        services.AddScoped<IVehicleTransmissionTypeService, VehicleTransmissionTypeService>();
        services.AddScoped<IVehicleEngineTypeService, VehicleEngineTypeService>();
        services.AddScoped<ILocationRegionService, LocationRegionService>();
        services.AddScoped<ILocationTownService, LocationTownService>();

        return services;
    }

    private static void AddJwtOptionsConfiguration(IServiceCollection services, IConfiguration config)
    {
        services.Configure<JwtTokenOptions>(options =>
        {
            options.Audience = config.GetSection("Jwt")["Audience"]!;
            options.Issuer = config.GetSection("Jwt")["Issuer"]!;
            options.SecretKey = config.GetSection("Jwt")["SecretKey"]!;
        });
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