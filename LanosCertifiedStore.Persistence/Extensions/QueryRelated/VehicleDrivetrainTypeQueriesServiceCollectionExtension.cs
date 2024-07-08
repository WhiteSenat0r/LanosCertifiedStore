using Domain.Entities.VehicleRelated.TypeRelated;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Queries.Common.Contracts;
using Persistence.Queries.TypeRelated.VehicleDrivetrainTypeRelated.QueryRelated;
using Persistence.Queries.TypeRelated.VehicleDrivetrainTypeRelated.SelectorRelated;

namespace Persistence.Extensions.QueryRelated;

internal static class VehicleDrivetrainTypeQueriesServiceCollectionExtension
{
    public static IServiceCollection AddVehicleDriveTrainTypeQueriesRelatedServices(this IServiceCollection services)
    {
        services.AddTransient<IQuerySortingSettingsSelector<VehicleDrivetrainType>,
            VehicleDrivetrainTypesSortingSettingsSelector>();

        services.AddTransient<CollectionVehicleDrivetrainTypesQuery>();
        
        return services;
    }
}