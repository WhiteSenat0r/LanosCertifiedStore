using Domain.Entities.VehicleRelated.LocationRelated;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Queries.Common.Contracts;
using Persistence.Queries.LocationRelated.LocationAreaRelated.QueryRelated;
using Persistence.Queries.LocationRelated.LocationAreaRelated.SelectorRelated;

namespace Persistence.Extensions.QueryRelated;

internal static class LocationAreaQueriesServiceCollectionExtensions
{
    public static IServiceCollection AddLocationAreaQueriesRelatedServices(this IServiceCollection services)
    {
        services.AddTransient<IQuerySortingSettingsSelector<VehicleLocationArea>, LocationAreaSortingSettingSelector>();

        services.AddTransient<CollectionLocationAreasQuery>();
        services.AddTransient<CountLocationAreasQuery>();
        
        return services;
    }
}