using Application.Shared.ResultRelated;
using MediatR;

namespace Application.VehicleColors.Queries.CollectionVehicleColorsQueryRequestRelated;

internal sealed class CollectionVehicleColorsQueryRequestHandler(IVehicleColorService vehicleColorService) :
    IRequestHandler<CollectionVehicleColorsQueryRequest, Result<PaginationResult<VehicleColorDto>>>
{
    public async Task<Result<PaginationResult<VehicleColorDto>>> Handle(CollectionVehicleColorsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var colors = await vehicleColorService.GetVehicleColorCollection(request, cancellationToken);

        var paginationResult = new PaginationResult<VehicleColorDto>(colors, request.FilteringParameters.PageIndex);
        
        return paginationResult;
    }
}