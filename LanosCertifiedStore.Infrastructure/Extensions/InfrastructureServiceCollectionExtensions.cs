using Application.Contracts.ServicesRelated;
using Application.Contracts.ServicesRelated.IdentityRelated;
using Application.Contracts.ServicesRelated.ImageService;
using LanosCertifiedStore.InfrastructureLayer.Services.Services;
using LanosCertifiedStore.InfrastructureLayer.Services.Services.IdentityRelated;
using LanosCertifiedStore.InfrastructureLayer.Services.Services.IdentityRelated.JwtTokenRelated;
using LanosCertifiedStore.InfrastructureLayer.Services.Services.ImagesRelated;
using LanosCertifiedStore.InfrastructureLayer.Services.Services.ImagesRelated.Common;
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