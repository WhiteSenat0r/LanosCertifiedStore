using Domain.Entities.VehicleRelated;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Queries.Common.Contracts;
using Persistence.Queries.VehicleColorRelated.QueryRelated;
using Persistence.Queries.VehicleColorRelated.SelectorRelated;

namespace Persistence.Extensions.QueryRelated;

internal static class VehicleColorQueriesServiceCollectionExtensions
{
    public static IServiceCollection AddVehicleColorQueriesRelatedServices(this IServiceCollection services)
    {
        services.AddTransient<IQuerySortingSettingsSelector<VehicleColor>, VehicleColorsSortingSettingsSelector>();

        services.AddTransient<CollectionVehicleColorsQuery>();
        services.AddTransient<CountVehicleColorsQuery>();

        return services;
    }
}