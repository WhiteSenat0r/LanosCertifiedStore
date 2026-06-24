using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Application.Vehicles.Queries.CountVehiclesQueryRelated;
using LanosCertifiedStore.Application.Vehicles.Queries.VehicleDetailsQueryRelated;
using LanosCertifiedStore.Application.Vehicles.Queries.VehiclesQueryRelated;

namespace LanosCertifiedStore.Application.Vehicles;

public interface IVehicleService
{
    Task<IEnumerable<VehicleDto>> GetVehicleCollection(
        VehiclesQueryRequest queryRequest,
        CancellationToken cancellationToken);

    Task<VehicleDto> GetSingleVehicle(
        VehicleSingleQueryRequest queryRequest,
        CancellationToken cancellationToken);

    Task<ItemsCountDto> GetVehiclesCount(
        CountVehiclesQueryRequest queryRequest,
        CancellationToken cancellationToken);
}
