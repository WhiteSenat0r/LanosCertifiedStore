using CloudinaryDotNet;
using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Application.Images;
using LanosCertifiedStore.Application.LocationRegions;
using LanosCertifiedStore.Application.LocationTowns;
using LanosCertifiedStore.Application.Users;
using LanosCertifiedStore.Application.VehicleBodyTypes;
using LanosCertifiedStore.Application.VehicleBrands;
using LanosCertifiedStore.Application.VehicleColors;
using LanosCertifiedStore.Application.VehicleDrivetrainTypes;
using LanosCertifiedStore.Application.VehicleEngineTypes;
using LanosCertifiedStore.Application.VehicleModels;
using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Application.VehicleTransmissionTypes;
using LanosCertifiedStore.Application.VehicleTypes;
using LanosCertifiedStore.Infrastructure.Authentication;
using LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;
using LanosCertifiedStore.Infrastructure.Authorization;
using LanosCertifiedStore.Infrastructure.Authorization.Claims;
using LanosCertifiedStore.Infrastructure.Health;
using LanosCertifiedStore.Infrastructure.Images;
using LanosCertifiedStore.Infrastructure.Locations;
using LanosCertifiedStore.Infrastructure.Users;
using LanosCertifiedStore.Infrastructure.Vehicles;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using IAuthorizationService = LanosCertifiedStore.Application.Users.IAuthorizationService;

namespace LanosCertifiedStore.Infrastructure;

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

        services.AddHealthChecks()
            .AddCheck<CloudinaryHealthCheck>("cloudinary", HealthStatus.Unhealthy)
            .AddNpgSql(configuration.GetConnectionString("PostgreSqlConnection")!);

        return services;
    }

    private static void AddAuthenticationRelatedServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication().AddJwtBearer();
        services.AddHttpContextAccessor();
        services.ConfigureOptions<JwtBearerConfigureOptions>();

        const string keyCloakSectionName = "KeyCloak";
        services.Configure<KeycloakOptions>(configuration.GetSection(keyCloakSectionName));
        services.AddTransient<KeycloakAuthDelegatingHandler>();

        services.AddHttpClient<KeycloakClient>((serviceProvider, httpClient) =>
            {
                var keyCloakOptions = serviceProvider
                    .GetRequiredService<IOptions<KeycloakOptions>>()
                    .Value;

                httpClient.BaseAddress = new Uri(keyCloakOptions.AdminUrl);
            })
            .AddHttpMessageHandler<KeycloakAuthDelegatingHandler>();

        services.AddScoped<IUserService, UserService>();
        services.AddTransient<IIdentityProviderService, IdentityProviderService>();
        services.AddScoped<IUserContext, UserContext>();
    }

    private static void AddAuthorizationRelatedServices(IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddScoped<IAuthorizationService, AuthorizationService>();
        services.AddTransient<IClaimsTransformation, CustomClaimsTransformation>();
        services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();
        services.AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
    }

    private static void AddImageRelatedServices(IServiceCollection services)
    {
        services.ConfigureOptions<CloudinaryConfigureOptions>();
        services.AddScoped<ICloudinary>(sp =>
        {
            var cloudinaryOptions = sp.GetRequiredService<IOptions<CloudinaryOptions>>();

            var cloudinaryAccount = new Account(
                cloudinaryOptions.Value.CloudName,
                cloudinaryOptions.Value.ApiKey,
                cloudinaryOptions.Value.ApiSecret
            );

            return new Cloudinary(cloudinaryAccount);
        });
        
        services.AddScoped<IImageService, ImageService>();
    }

    private static void AddVehicleRelatedServices(IServiceCollection services)
    {
        services.AddScoped<IVehicleService, VehicleService>();
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