using Domain.Entities.VehicleRelated.TypeRelated;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Queries.Common.Contracts;
using Persistence.Queries.TypeRelated.VehicleBodyTypeRelated.QueryRelated;
using Persistence.Queries.TypeRelated.VehicleBodyTypeRelated.SelectorRelated;

namespace Persistence.Extensions.QueryRelated;

internal static class VehicleBodyTypeQueriesServiceCollectionExtensions
{
    public static IServiceCollection AddVehicleBodyTypeQueriesRelatedServices(this IServiceCollection services)
    {
        services.AddTransient<IQuerySortingSettingsSelector<VehicleBodyType>, VehicleBodyTypesSortingSettingsSelector>();

        services.AddTransient<CollectionVehicleBodyTypesQuery>();
        services.AddTransient<CountVehicleBodyTypesQuery>();

        return services;
    }
}