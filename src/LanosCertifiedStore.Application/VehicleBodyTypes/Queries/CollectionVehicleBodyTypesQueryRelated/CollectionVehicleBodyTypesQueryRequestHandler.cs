using Application.Shared.ResultRelated;
using MediatR;

namespace Application.VehicleBodyTypes.Queries.CollectionVehicleBodyTypesQueryRelated;

internal sealed class CollectionVehicleBodyTypesQueryRequestHandler(IVehicleBodyTypeService vehicleBodyTypeService)
    : IRequestHandler<CollectionVehicleBodyTypesQueryRequest, Result<PaginationResult<VehicleBodyTypeDto>>>
{
    public async Task<Result<PaginationResult<VehicleBodyTypeDto>>> Handle(
        CollectionVehicleBodyTypesQueryRequest request, CancellationToken cancellationToken)
    {
        var bodyTypes = await vehicleBodyTypeService.GetVehicleBodyTypeCollection(request, cancellationToken);

        var paginationResult =
            new PaginationResult<VehicleBodyTypeDto>(bodyTypes, request.FilteringParameters.PageIndex);

        return paginationResult;
    }
}