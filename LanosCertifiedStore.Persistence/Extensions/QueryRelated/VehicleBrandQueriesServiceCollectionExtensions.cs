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
        services.AddTransient<IQuerySortingSettingsSelector<VehicleBrand>, VehicleBrandsSortingSettingsSelector>();
        services.AddTransient<IQueryProjectionProfileSelector<VehicleBrand>, VehicleBrandsProjectionProfileSelector>();
        services.AddTransient<IQueryFilteringCriteriaSelector<VehicleBrand>, VehicleBrandsFilteringCriteriaSelector>();
        
        services.AddTransient<CollectionVehicleBrandsQuery>();
        services.AddTransient<SingleVehicleBrandQuery>();
        services.AddTransient<CountVehicleBrandsQuery>();

        return services;
    }
}