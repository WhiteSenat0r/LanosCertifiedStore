using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;

namespace InfrastructureUnitTests;

internal static class DbContextAccessor
{
    private static ApplicationDatabaseContext InstantiateDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDatabaseContext>()
            .UseInMemoryDatabase(databaseName: "dbTest")
            .Options;

        var context = new ApplicationDatabaseContext(options);

        return context;
    }
}