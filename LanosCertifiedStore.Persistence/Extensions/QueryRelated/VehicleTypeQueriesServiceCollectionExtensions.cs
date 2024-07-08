using Domain.Entities.VehicleRelated.TypeRelated;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Queries.Common.Contracts;
using Persistence.Queries.TypeRelated.VehicleTypeRelated.QueryRelated;
using Persistence.Queries.TypeRelated.VehicleTypeRelated.SelectorRelated;

namespace Persistence.Extensions.QueryRelated;

internal static class VehicleTypeQueriesServiceCollectionExtensions
{
    public static IServiceCollection AddVehicleTypeQueriesRelatedServices(this IServiceCollection services)
    {
        services.AddTransient<IQuerySortingSettingsSelector<VehicleType>, VehicleTypesSortingSettingsSelector>();

        services.AddTransient<CollectionVehicleTypesQuery>();
        
        return services;
    }
}