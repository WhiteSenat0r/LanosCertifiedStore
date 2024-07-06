using Microsoft.Extensions.DependencyInjection;
using Persistence.Queries.LocationRelated.LocationRegionRelated;

namespace Persistence.Extensions.QueryRelated;

internal static class LocationRegionQueriesServiceCollectionExtensions
{
    public static IServiceCollection AddLocationRegionQueriesRelatedServices(this IServiceCollection services)
    {
        services.AddTransient<LocationRegionExistsByIdQuery>();
        
        return services;
    }

}