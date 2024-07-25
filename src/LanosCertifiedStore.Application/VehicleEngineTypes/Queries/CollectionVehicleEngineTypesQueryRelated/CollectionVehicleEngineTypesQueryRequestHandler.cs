using Application.Shared.ResultRelated;
using MediatR;

namespace Application.VehicleEngineTypes.Queries.CollectionVehicleEngineTypesQueryRelated;

internal sealed class CollectionVehicleEngineTypesQueryRequestHandler(
    IVehicleEngineTypeService vehicleEngineTypeService)
    : IRequestHandler<CollectionVehicleEngineTypesQueryRequest, Result<PaginationResult<VehicleEngineTypeDto>>>
{
    public async Task<Result<PaginationResult<VehicleEngineTypeDto>>> Handle(
        CollectionVehicleEngineTypesQueryRequest request, CancellationToken cancellationToken)
    {
        var bodyTypes = await vehicleEngineTypeService.GetVehicleEngineTypeCollection(request, cancellationToken);

        var paginationResult =
            new PaginationResult<VehicleEngineTypeDto>(bodyTypes, request.FilteringParameters.PageIndex);

        return paginationResult;
    }
}