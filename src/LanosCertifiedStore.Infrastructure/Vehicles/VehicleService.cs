using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Application.Vehicles.Queries.CountVehiclesQueryRelated;
using LanosCertifiedStore.Application.Vehicles.Queries.VehicleDetailsQueryRelated;
using LanosCertifiedStore.Application.Vehicles.Queries.VehiclesQueryRelated;
using LanosCertifiedStore.Persistence.Queries.VehicleRelated.QueryRelated;

namespace LanosCertifiedStore.Infrastructure.Vehicles;

internal sealed class VehicleService(
    CollectionVehiclesQuery collectionVehiclesQuery,
    SingleVehicleQuery singleVehicleQuery,
    CountVehiclesQuery countVehiclesQuery) : IVehicleService
{
    public async Task<IReadOnlyCollection<VehicleDto>> GetVehicleCollection(
        VehiclesQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await collectionVehiclesQuery.Execute(queryRequest, cancellationToken);
    }

    public async Task<VehicleDto?> GetSingleVehicle(
        VehicleSingleQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await singleVehicleQuery.Execute(queryRequest, cancellationToken);
    }

    public async Task<ItemsCountDto> GetVehiclesCount(
        CountVehiclesQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await countVehiclesQuery.Execute(queryRequest, cancellationToken);
    }
}
