using Application.Contracts.ServicesRelated.IdentityRelated;
using Application.Contracts.ServicesRelated.ImageService;
using LanosCertifiedStore.InfrastructureLayer.Services.IdentityRelated;
using LanosCertifiedStore.InfrastructureLayer.Services.ImagesRelated;
using LanosCertifiedStore.InfrastructureLayer.Services.ImagesRelated.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Extensions;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddExternalServices(this IServiceCollection services, IConfiguration config)
    {
        AddCloudinaryConfiguration(services, config);

        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        
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