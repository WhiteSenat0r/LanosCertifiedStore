namespace API.Extensions;

internal static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy",
                policy => { policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(config["ClientUrl"]!); });
        });

        return services;
    }
}