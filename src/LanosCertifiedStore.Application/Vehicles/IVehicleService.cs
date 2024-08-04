using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Application.Vehicles.Queries.CollectionVehiclesQueryRelated;
using LanosCertifiedStore.Application.Vehicles.Queries.CountVehiclesQueryRelated;
using LanosCertifiedStore.Application.Vehicles.Queries.SingleVehicleQueryRequestRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.Vehicles;

public interface IVehicleService
{
    Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken = default);

    Task<SingleVehicleDto?> GetVehicle(
        SingleVehicleQueryRequest request,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<VehicleDto>> GetVehicles(
        CollectionVehiclesQueryRequest request,
        CancellationToken cancellationToken = default);

    Task<ItemsCountDto> GetVehiclesCount(
        CountVehiclesQueryRequest request,
        CancellationToken cancellationToken = default);
}