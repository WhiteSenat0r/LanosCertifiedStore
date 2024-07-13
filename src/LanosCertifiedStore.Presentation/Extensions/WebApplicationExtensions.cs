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
            var seedData = new SeedData(application.Environment.WebRootPath, context);
            await seedData.Seed();
        }

        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occured during migration!");
        }
    }
}