using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.VehicleDrivetrainTypes.Queries.
    CollectionVehicleDrivetrainTypesQueryRequestRelated;

internal sealed class CollectionVehicleDrivetrainTypesQueryRequestHandler(
    IVehicleDrivetrainTypeService vehicleDrivetrainTypeService) :
    IRequestHandler<CollectionVehicleDrivetrainTypesQueryRequest, Result<PaginationResult<VehicleDrivetrainTypeDto>>>
{
    public async Task<Result<PaginationResult<VehicleDrivetrainTypeDto>>> Handle(
        CollectionVehicleDrivetrainTypesQueryRequest request, CancellationToken cancellationToken)
    {
        var vehicleDriveTrainTypes = await vehicleDrivetrainTypeService
            .GetVehicleDrivetrainTypeCollection(request, cancellationToken);

        var paginationResult = new PaginationResult<VehicleDrivetrainTypeDto>(
            vehicleDriveTrainTypes,
            request.FilteringParameters.PageIndex);

        return paginationResult;
    }
}