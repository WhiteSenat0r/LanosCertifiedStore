using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.SeedingData;

namespace API.Extensions;

internal static class WebApplicationExtensions
{
    public static async Task ExecuteMigration(this WebApplication application)
    {
        if (!application.Environment.IsDevelopment())
        {
            return;
        }
            
        using var scope = application.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<ApplicationDatabaseContext>();
            await context.Database.MigrateAsync();
            await SeedData.Seed(context, application.Environment.WebRootPath);
        }

        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occured during migration!");
        }
    }
}