using Application.Contracts.ServicesRelated;
using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.TypesRelated.VehicleDrivetrainTypeRelated.
    CollectionVehicleDrivetrainTypesQueryRequestRelated;

internal sealed class CollectionVehicleDrivetrainTypesQueryRequestHandler(
    IVehicleDrivetrainTypeService vehicleDrivetrainTypeService) :
    IRequestHandler<CollectionVehicleDrivetrainTypesQueryRequest, Result<PaginationResult<VehicleDrivetrainTypeDto>>>
{
    public async Task<Result<PaginationResult<VehicleDrivetrainTypeDto>>> Handle(
        CollectionVehicleDrivetrainTypesQueryRequest request, CancellationToken cancellationToken)
    {
        var vehicleDriveTrainTypes = await vehicleDrivetrainTypeService
            .GetVehicleTypeCollection(request, cancellationToken);

        var paginationResult = new PaginationResult<VehicleDrivetrainTypeDto>(
            vehicleDriveTrainTypes,
            request.FilteringParameters.PageIndex);

        return Result<PaginationResult<VehicleDrivetrainTypeDto>>.Success(paginationResult);
    }
}