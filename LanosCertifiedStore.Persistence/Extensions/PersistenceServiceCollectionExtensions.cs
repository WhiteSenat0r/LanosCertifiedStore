using Application.Contracts.ServicesRelated.RequestRelated;
using Application.Helpers.ValidationRelated.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Extensions.CommandRelated;
using Persistence.Extensions.QueryRelated;
using Persistence.Services;
using Persistence.Services.ValidationRelated;
using Persistence.Shared.MappingRelated;
using Persistence.Shared.MappingRelated.Common.Contracts;

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
        services.AddCommandRelatedServices();

        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<IModelEntityMappings, ModelEntityMappings>();
        services.AddScoped(typeof(IInputValidationService), typeof(InputValidationService));

        return services;
    }
}