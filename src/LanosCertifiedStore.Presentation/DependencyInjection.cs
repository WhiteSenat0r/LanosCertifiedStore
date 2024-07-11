using API.Middlewares.ExceptionRelated;

namespace API;

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
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(config["ClientUrl"]!);
                });
        });

        // OverrideAuthenticationScheme(services);
        // AddJwtAuthenticationOptions(services, config);
        
        services.AddAuthorization();
        
        services.AddExceptionHandler<DatabaseConnectionExceptionHandler>();
        services.AddExceptionHandler<DatabaseUpdateExceptionHandler>();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        return services;
    }
    
    // TODO Move to the infrastructure layer
    // private static void AddJwtAuthenticationOptions(
    //     IServiceCollection serviceCollection, IConfiguration configuration)
    // {
    //     serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    //         .AddCookie(options =>
    //         {
    //             options.Cookie.Name = "UserAccessToken";
    //         })
    //         .AddJwtBearer(options =>
    //         {
    //             options.TokenValidationParameters = new TokenValidationParameters
    //             {
    //                 ValidateIssuerSigningKey = true,
    //                 IssuerSigningKey = new SymmetricSecurityKey(
    //                     Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]!)),
    //                 ValidIssuer = configuration["Jwt:Issuer"],
    //                 ValidAudience = configuration["Jwt:Audience"],
    //                 ValidateIssuer = true,
    //                 ValidateAudience = true,
    //                 ValidateLifetime = true,
    //                 ClockSkew = TimeSpan.Zero
    //             };
    //
    //             options.Events = new JwtBearerEvents
    //             {
    //                 OnMessageReceived = context =>
    //                 {
    //                     context.Token = context.Request.Cookies["UserAccessToken"];
    //                     return Task.CompletedTask;
    //                 }
    //             };
    //         });
    // }
    //
    // private static void OverrideAuthenticationScheme(IServiceCollection serviceCollection)
    // {
    //     serviceCollection.AddAuthentication(options =>
    //     {
    //         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //         options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    //     });
    // }
}