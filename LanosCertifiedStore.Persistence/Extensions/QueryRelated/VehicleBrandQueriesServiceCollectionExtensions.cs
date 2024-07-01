using Domain.Entities.VehicleRelated;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Queries.Common.Contracts;
using Persistence.Queries.VehicleBrandRelated.QueryRelated;
using Persistence.Queries.VehicleBrandRelated.SelectorRelated;

namespace Persistence.Extensions.QueryRelated;

internal static class VehicleBrandQueriesServiceCollectionExtensions
{
    public static IServiceCollection AddVehicleBrandQueriesRelatedServices(this IServiceCollection services)
    {
        services.AddTransient<IQuerySortingSettingsSelector<VehicleBrand, VehicleBrand>,
            VehicleBrandsSortingSettingsSelector>();
        services.AddTransient<IQueryProjectionProfileSelector<VehicleBrand, VehicleBrand>,
            VehicleBrandsProjectionProfileSelector>();
        services.AddTransient<IQueryFilteringCriteriaSelector<VehicleBrand, VehicleBrand>,
            VehicleBrandsFilteringCriteriaSelector>();
        
        services.AddTransient<IQuery<VehicleBrand, IReadOnlyCollection<VehicleBrand>>, CollectionVehicleBrandsQuery>();
        services.AddTransient<IQuery<VehicleBrand, VehicleBrand>, SingleVehicleBrandQuery>();
        services.AddTransient<IQuery<VehicleBrand, Tuple<int, int>>, CountVehicleBrandsQuery>();

        return services;
    }
}