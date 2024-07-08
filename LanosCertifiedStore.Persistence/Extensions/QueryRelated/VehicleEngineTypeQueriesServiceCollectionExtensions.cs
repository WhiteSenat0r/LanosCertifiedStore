using Domain.Entities.VehicleRelated.TypeRelated;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Queries.Common.Contracts;
using Persistence.Queries.TypeRelated.VehicleEngineTypeRelated.QueryRelated;
using Persistence.Queries.TypeRelated.VehicleEngineTypeRelated.SelectorRelated;

namespace Persistence.Extensions.QueryRelated;

internal static class VehicleEngineTypeQueriesServiceCollectionExtensions
{
    public static IServiceCollection AddVehicleEngineTypeQueriesRelatedServices(this IServiceCollection services)
    {
        services.AddTransient<IQuerySortingSettingsSelector<VehicleEngineType>,
            VehicleEngineTypesSortingSettingsSelector>();

        services.AddTransient<CollectionVehicleEngineTypesQuery>();

        return services;
    }
}