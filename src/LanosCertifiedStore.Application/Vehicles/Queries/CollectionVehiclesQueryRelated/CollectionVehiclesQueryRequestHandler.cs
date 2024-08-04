using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Queries.CollectionVehiclesQueryRelated;

internal sealed class CollectionVehiclesQueryRequestHandler(IVehicleService vehicleService) :
    IRequestHandler<CollectionVehiclesQueryRequest, Result<PaginationResult<VehicleDto>>>
{
    public async Task<Result<PaginationResult<VehicleDto>>> Handle(
        CollectionVehiclesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var vehicles = await vehicleService.GetVehicles(request, cancellationToken);

        var paginationResult = new PaginationResult<VehicleDto>(vehicles, request.FilteringParameters.PageIndex);

        return paginationResult;
    }
}