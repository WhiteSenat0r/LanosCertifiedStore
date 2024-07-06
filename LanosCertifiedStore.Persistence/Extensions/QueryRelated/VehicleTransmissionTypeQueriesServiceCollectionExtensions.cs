using Domain.Entities.VehicleRelated.TypeRelated;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Queries.Common.Contracts;
using Persistence.Queries.TypeRelated.VehicleTransmissionTypeRelated.QueryRelated;
using Persistence.Queries.TypeRelated.VehicleTransmissionTypeRelated.SelectorRelated;

namespace Persistence.Extensions.QueryRelated;

internal static class VehicleTransmissionTypeQueriesServiceCollectionExtensions
{
    public static IServiceCollection AddVehicleTransmissionTypeQueriesRelatedServices(this IServiceCollection services)
    {
        services.AddTransient<IQuerySortingSettingsSelector<VehicleTransmissionType>,
            VehicleTransmissionTypesSortingSettingsSelector>();

        services.AddTransient<CollectionVehicleTransmissionTypesQuery>();
        services.AddTransient<CountVehicleTransmissionTypesQuery>();

        return services;
    }
}