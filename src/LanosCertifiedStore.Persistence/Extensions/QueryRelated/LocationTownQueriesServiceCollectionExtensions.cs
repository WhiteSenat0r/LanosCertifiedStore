using Domain.Entities.VehicleRelated.LocationRelated;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Queries.Common.Contracts;
using Persistence.Queries.LocationRelated.LocationTownRelated.QueryRelated;
using Persistence.Queries.LocationRelated.LocationTownRelated.SelectorRelated;

namespace Persistence.Extensions.QueryRelated;

internal static class LocationTownQueriesServiceCollectionExtensions
{
    public static IServiceCollection AddLocationTownQueriesRelatedServices(this IServiceCollection services)
    {
        services.AddTransient<IQuerySortingSettingsSelector<VehicleLocationTown>,
            LocationTownSortingSettingsSelector>();
        services.AddTransient<IQueryFilteringCriteriaSelector<VehicleLocationTown>,
            LocationTownFilteringCriteriaSelector>();
        
        services.AddTransient<CollectionLocationTownsQuery>();
        services.AddTransient<CountLocationTownsQuery>();
            
        return services;
    }

}