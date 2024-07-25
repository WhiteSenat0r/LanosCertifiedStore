using Application.Identity;
using Application.Images;
using Application.LocationRegions;
using Application.LocationTowns;
using Application.Users;
using Application.VehicleBodyTypes;
using Application.VehicleBrands;
using Application.VehicleColors;
using Application.VehicleDrivetrainTypes;
using Application.VehicleEngineTypes;
using Application.VehicleModels;
using Application.VehicleTransmissionTypes;
using Application.VehicleTypes;
using LanosCertifiedStore.InfrastructureLayer.Services.Authentication;
using LanosCertifiedStore.InfrastructureLayer.Services.Authentication.KeyCloak;
using LanosCertifiedStore.InfrastructureLayer.Services.Authorization;
using LanosCertifiedStore.InfrastructureLayer.Services.Images;
using LanosCertifiedStore.InfrastructureLayer.Services.Locations;
using LanosCertifiedStore.InfrastructureLayer.Services.Users;
using LanosCertifiedStore.InfrastructureLayer.Services.Vehicles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using IAuthorizationService = Application.Users.IAuthorizationService;

namespace LanosCertifiedStore.InfrastructureLayer.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddExternalServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddImageRelatedServices(services);
        AddVehicleRelatedServices(services);
        AddTypeRelatedServices(services);
        AddLocationRelatedServices(services);
        AddAuthenticationRelatedServices(services, configuration);
        AddAuthorizationRelatedServices(services);

        return services;
    }

    private static void AddAuthenticationRelatedServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication().AddJwtBearer();
        services.AddHttpContextAccessor();
        services.ConfigureOptions<JwtBearerConfigureOptions>();

        const string keyCloakSectionName = "KeyCloak";
        services.Configure<KeyCloakOptions>(configuration.GetSection(keyCloakSectionName));
        services.AddTransient<KeyCloakAuthDelegatingHandler>();

        services.AddHttpClient<KeyCloakClient>((serviceProvider, httpClient) =>
        {
            var keyCloakOptions = serviceProvider
                .GetRequiredService<IOptions<KeyCloakOptions>>()
                .Value;

            httpClient.BaseAddress = new Uri(keyCloakOptions.AdminUrl);
        })
        .AddHttpMessageHandler<KeyCloakAuthDelegatingHandler>();

        services.AddScoped<IUserService, UserService>();
        services.AddTransient<IIdentityProviderService, IdentityProviderService>();
    }
    
    private static void AddAuthorizationRelatedServices(IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddScoped<IAuthorizationService, AuthorizationService>();
        // services.AddTransient<IClaimsTransformation, CustomClaimsTransformation>();
        services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();
        services.AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
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