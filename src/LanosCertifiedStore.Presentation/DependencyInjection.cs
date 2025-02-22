using LanosCertifiedStore.Presentation.Middlewares.ExceptionRelated;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;

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

        services.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService("LanosCertifiedStore"))
            .WithMetrics(metrics =>
            {
                metrics.AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation();

                metrics.AddOtlpExporter();
            });

        services.AddExceptionHandler<DatabaseConnectionExceptionHandler>();
        services.AddExceptionHandler<DatabaseUpdateExceptionHandler>();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        return services;
    }
}