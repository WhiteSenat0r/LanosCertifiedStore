using Domain.Entities.VehicleRelated.LocationRelated;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Queries.Common.Contracts;
using Persistence.Queries.LocationRelated.LocationRegionRelated.QueryRelated;
using Persistence.Queries.LocationRelated.LocationRegionRelated.SelectorRelated;

namespace Persistence.Extensions.QueryRelated;

internal static class LocationRegionQueriesServiceCollectionExtensions
{
    public static IServiceCollection AddLocationRegionQueriesRelatedServices(this IServiceCollection services)
    {
        services.AddTransient<IQuerySortingSettingsSelector<VehicleLocationRegion>,
            LocationRegionSortingSettingsSelector>();
        
        services.AddTransient<CollectionLocationRegionsQuery>();
            
        return services;
    }

}