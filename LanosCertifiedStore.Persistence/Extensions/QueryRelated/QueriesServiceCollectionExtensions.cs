using Microsoft.Extensions.DependencyInjection;
using Persistence.Queries.Common.Classes;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Extensions.QueryRelated;

internal static class QueriesServiceCollectionExtensions
{
    public static IServiceCollection AddQueryRelatedServices(this IServiceCollection services)
    {
        AddCommonServices(services);

        services.AddVehicleBrandQueriesRelatedServices();
        services.AddVehicleTypeQueriesRelatedServices();
        services.AddVehicleColorQueriesRelatedServices();
        services.AddVehicleBodyTypeQueriesRelatedServices();
        services.AddVehicleDriveTrainTypeQueriesRelatedServices();
        services.AddVehicleTransmissionTypeQueriesRelatedServices();
        services.AddVehicleEngineTypeQueriesRelatedServices();
        services.AddLocationRegionQueriesRelatedServices();
        services.AddLocationTownQueriesRelatedServices();

        return services;
    }

    private static void AddCommonServices(IServiceCollection services)
    {
        services.AddScoped<IQueryPaginator, QueryPaginator>();
    }
}