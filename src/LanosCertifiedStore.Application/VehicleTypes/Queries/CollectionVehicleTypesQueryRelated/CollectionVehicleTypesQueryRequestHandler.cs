using Application.Shared.ResultRelated;
using MediatR;

namespace Application.VehicleTypes.Queries.CollectionVehicleTypesQueryRelated;

internal sealed class CollectionVehicleTypesQueryRequestHandler(IVehicleTypeService vehicleTypeService) :
    IRequestHandler<CollectionVehicleTypesQueryRequest, Result<PaginationResult<VehicleTypeDto>>>
{
    public async Task<Result<PaginationResult<VehicleTypeDto>>> Handle(
        CollectionVehicleTypesQueryRequest request, CancellationToken cancellationToken)
    {
        var types = await vehicleTypeService.GetVehicleTypeCollection(request, cancellationToken);

        var paginationResult = new PaginationResult<VehicleTypeDto>(types, request.FilteringParameters.PageIndex);

        return paginationResult;
    }
}