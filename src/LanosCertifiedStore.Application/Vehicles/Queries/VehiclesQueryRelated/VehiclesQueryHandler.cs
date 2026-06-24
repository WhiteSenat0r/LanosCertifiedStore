using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Queries.VehiclesQueryRelated;

internal sealed class VehiclesQueryHandler(IVehicleService vehicleService) :
    IRequestHandler<VehiclesQueryRequest, Result<PaginationResult<VehicleDto>>>
{
    public async Task<Result<PaginationResult<VehicleDto>>> Handle(
        VehiclesQueryRequest request, CancellationToken cancellationToken)
    {
        var vehicles = await vehicleService.GetVehicleCollection(request, cancellationToken);

        var paginationResult = new PaginationResult<VehicleDto>(vehicles, request.FilteringParameters.PageIndex);

        return paginationResult;
    }
}