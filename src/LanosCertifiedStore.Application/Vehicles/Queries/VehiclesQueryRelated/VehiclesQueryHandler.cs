using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Queries.VehiclesQueryRelated;

internal sealed class VehiclesQueryHandler(IVehicleService vehicleService) :
    IRequestHandler<VehiclesQueryRequest, Result<PaginationResult<VehicleDto>>>
{
    public async Task<Result<PaginationResult<VehicleDto>>> Handle(
        VehiclesQueryRequest request, CancellationToken cancellationToken) =>
        new PaginationResult<VehicleDto>(
            await vehicleService.GetVehicleCollection(request, cancellationToken),
            request.FilteringParameters.PageIndex);
}