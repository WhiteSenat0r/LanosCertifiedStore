using Domain.Models.VehicleRelated.Classes;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Entities.VehicleRelated;
using Persistence.Queries.Common.Contracts;
using Persistence.Queries.VehicleBrandRelated;

namespace Persistence.Extensions.QueryRelated;

internal static class VehicleBrandQueriesServiceCollectionExtensions
{
    public static IServiceCollection AddVehicleBrandQueriesRelatedServices(this IServiceCollection services)
    {
        services.AddTransient<IQuerySortingSettingsSelector<VehicleBrand, VehicleBrandEntity>,
            VehicleBrandsSortingSettingsSelector>();
        services.AddTransient<IQueryProjectionProfileSelector<VehicleBrand, VehicleBrandEntity>,
            VehicleBrandsProjectionProfileSelector>();
        services.AddTransient<IQueryFilteringCriteriaSelector<VehicleBrand, VehicleBrandEntity>,
            VehicleBrandsFilteringCriteriaSelector>();
        
        services.AddTransient<IQuery<VehicleBrand, IReadOnlyCollection<VehicleBrand>>, CollectionVehicleBrandsQuery>();
        services.AddTransient<IQuery<VehicleBrand, VehicleBrand>, SingleVehicleBrandQuery>();

        return services;
    }
}