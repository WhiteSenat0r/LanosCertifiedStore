using Application.Contracts.ServicesRelated.RequestRelated;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Factories.QueryRelated.Common.Classes;
using Persistence.Factories.QueryRelated.Common.Contracts;
using Persistence.Queries.Common.Classes;
using Persistence.Queries.Common.Contracts;
using Persistence.Services.QueryRelated;

namespace Persistence.Extensions.QueryRelated;

internal static class QueriesServiceCollectionExtensions
{
    public static IServiceCollection AddQueryRelatedServices(this IServiceCollection services)
    {
        AddCommonServices(services);
        
        services.AddVehicleBrandQueriesRelatedServices();

        return services;
    }

    private static void AddCommonServices(IServiceCollection services)
    {
        services.AddScoped<IQueryPaginator, QueryPaginator>();
        services.AddScoped<IQueryFactory, QueryFactory>(provider => InitializeQueryFactory(services, provider));
        services.AddScoped<IQueryService, QueryService>();
    }

    private static QueryFactory InitializeQueryFactory(IServiceCollection services, IServiceProvider provider)
    {
        var queryDescriptors = services.Where(
                serviceDescriptor => serviceDescriptor.ServiceType.IsGenericType &&
                                     serviceDescriptor.ServiceType.GetGenericTypeDefinition() == typeof(IQuery<,>))
            .ToList();

        var serviceTypes = queryDescriptors.Select(d => d.ServiceType);

        var queries = serviceTypes.Select(type => provider.GetService(type)!).ToList();

        var queryFactory = new QueryFactory(queries);

        return queryFactory;
    }
}