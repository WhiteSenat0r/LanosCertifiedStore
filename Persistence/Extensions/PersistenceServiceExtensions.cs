using Domain.Contracts.RepositoryRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;

namespace Persistence.Extensions;

public static class PersistenceServiceExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDatabaseContext>(option =>
        {
            option.UseSqlServer(config.GetConnectionString("SqlServerConnection"),
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        });
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
}