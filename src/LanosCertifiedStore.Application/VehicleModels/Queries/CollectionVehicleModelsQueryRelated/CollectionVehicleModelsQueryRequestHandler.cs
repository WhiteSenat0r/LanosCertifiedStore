using Application.Shared.ResultRelated;
using Application.VehicleModels.Dtos;
using MediatR;

namespace Application.VehicleModels.Queries.CollectionVehicleModelsQueryRelated;

internal sealed class CollectionVehicleModelsQueryRequestHandler(IVehicleModelService vehicleModelService) : 
    IRequestHandler<CollectionVehicleModelsQueryRequest, Result<PaginationResult<VehicleModelDto>>>
{
    public async Task<Result<PaginationResult<VehicleModelDto>>> Handle(
        CollectionVehicleModelsQueryRequest request, CancellationToken cancellationToken)
    {
        var brands = await vehicleModelService.GetVehicleModelCollection(request, cancellationToken);

        return Result<PaginationResult<VehicleModelDto>>.Success(
            new PaginationResult<VehicleModelDto>(brands, request.FilteringParameters.PageIndex));
    }
}