using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Application.Vehicles.Queries.CollectionVehiclesQueryRelated;
using LanosCertifiedStore.Application.Vehicles.Queries.CountVehiclesQueryRelated;
using LanosCertifiedStore.Application.Vehicles.Queries.SingleVehicleQueryRequestRelated;
using LanosCertifiedStore.Application.Vehicles.Queries.VehiclePriceRangeQueryRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Commands.Common;
using LanosCertifiedStore.Persistence.Commands.VehicleRelated;
using LanosCertifiedStore.Persistence.Queries.VehicleRelated.QueryRelated;

namespace LanosCertifiedStore.Infrastructure.Vehicles;

internal sealed class VehicleService(
    CreateVehicleCommand createVehicleCommand,
    CollectionVehiclesQuery collectionVehiclesQuery,
    SingleVehicleQuery singleVehicleQuery,
    CountVehiclesQuery countVehiclesQuery,
    PriceRangeQuery priceRangeQuery,
    SaveChangesCommand saveChangesCommand) : IVehicleService
{
    public async Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken)
    {
        await createVehicleCommand.Execute(vehicle, cancellationToken);
        await saveChangesCommand.Execute(cancellationToken);
    }

    public async Task<SingleVehicleDto?> GetVehicle(
        SingleVehicleQueryRequest request,
        CancellationToken cancellationToken = default)
    {
        return await singleVehicleQuery.Execute(request, cancellationToken);
    }

    public async Task<IReadOnlyCollection<VehicleDto>> GetVehicles(
        CollectionVehiclesQueryRequest request,
        CancellationToken cancellationToken = default)
    {
        return await collectionVehiclesQuery.Execute(request, cancellationToken);
    }

    public async Task<ItemsCountDto> GetVehiclesCount(
        CountVehiclesQueryRequest request,
        CancellationToken cancellationToken = default)
    {
        return await countVehiclesQuery.Execute(request, cancellationToken);
    }

    public async Task<PriceRangeDto> GetPriceRange(VehiclePriceRangeQueryRequest request, CancellationToken cancellationToken = default)
    {
        return await priceRangeQuery.Execute(request.RequestParameters, cancellationToken);
    }
}