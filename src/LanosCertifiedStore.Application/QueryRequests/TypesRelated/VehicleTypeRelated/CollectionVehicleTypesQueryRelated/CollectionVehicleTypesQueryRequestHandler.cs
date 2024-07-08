using Application.Contracts.ServicesRelated;
using Application.Dtos.TypeDtos;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.TypesRelated.VehicleTypeRelated.CollectionVehicleTypesQueryRelated;

internal sealed class CollectionVehicleTypesQueryRequestHandler(IVehicleTypeService vehicleTypeService) : 
    IRequestHandler<CollectionVehicleTypesQueryRequest, Result<PaginationResult<VehicleTypeDto>>>
{
    public async Task<Result<PaginationResult<VehicleTypeDto>>> Handle(
        CollectionVehicleTypesQueryRequest request, CancellationToken cancellationToken)
    {
        var types = await vehicleTypeService.GetVehicleTypeCollection(request, cancellationToken);

        return Result<PaginationResult<VehicleTypeDto>>.Success(
            new PaginationResult<VehicleTypeDto>(types, request.FilteringParameters.PageIndex));
    }
}