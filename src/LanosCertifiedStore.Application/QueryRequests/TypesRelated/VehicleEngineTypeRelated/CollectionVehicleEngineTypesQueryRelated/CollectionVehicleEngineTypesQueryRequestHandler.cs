using Application.Contracts.ServicesRelated;
using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.TypesRelated.VehicleEngineTypeRelated.CollectionVehicleEngineTypesQueryRelated;

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

        return Result<PaginationResult<VehicleEngineTypeDto>>.Success(paginationResult);
    }
}