﻿using LanosCertifiedStore.Presentation.Middlewares.ExceptionRelated;

namespace LanosCertifiedStore.Presentation;

internal static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration config)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy",
                policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(
                        config["ClientUrl"]!,
                        config.GetSection("Keycloak")["BaseMessagingUrl"]!);
                });
        });
        
        services.AddExceptionHandler<DatabaseConnectionExceptionHandler>();
        services.AddExceptionHandler<DatabaseUpdateExceptionHandler>();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        return services;
    }
}