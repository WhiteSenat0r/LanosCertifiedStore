using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions;

internal static class ApiServiceCollectionExtensions
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

        OverrideAuthenticationScheme(services);
        AddJwtAuthenticationOptions(services, config);
        services.AddAuthorization();

        return services;
    }
    
    private static void AddJwtAuthenticationOptions(
        IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "UserAccessToken";
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]!)),
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["UserAccessToken"];
                        return Task.CompletedTask;
                    }
                };
            });
    }

    private static void OverrideAuthenticationScheme(IServiceCollection serviceCollection)
    {
        serviceCollection.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        });
    }
}