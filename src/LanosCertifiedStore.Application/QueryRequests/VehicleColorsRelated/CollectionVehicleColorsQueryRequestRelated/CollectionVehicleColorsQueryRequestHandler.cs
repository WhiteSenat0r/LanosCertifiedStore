using Application.Contracts.ServicesRelated;
using Application.Dtos.ColorDtos;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.VehicleColorsRelated.CollectionVehicleColorsQueryRequestRelated;

internal sealed class CollectionVehicleColorsQueryRequestHandler(IVehicleColorService vehicleColorService) :
    IRequestHandler<CollectionVehicleColorsQueryRequest, Result<PaginationResult<VehicleColorDto>>>
{
    public async Task<Result<PaginationResult<VehicleColorDto>>> Handle(CollectionVehicleColorsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var colors = await vehicleColorService.GetVehicleColorCollection(request, cancellationToken);

        return Result<PaginationResult<VehicleColorDto>>.Success(
            new PaginationResult<VehicleColorDto>(colors, request.FilteringParameters.PageIndex));
    }
}