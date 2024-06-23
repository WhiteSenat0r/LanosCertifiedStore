using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Extensions.QueryRelated;

namespace Persistence.Extensions;

public static class PersistenceServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDatabaseContext>(option =>
        {
            option.UseNpgsql(config.GetConnectionString("PostgreSqlConnection"),
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        });

        services.AddQueryRelatedServices();

        return services;
    }
}