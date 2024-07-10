using Application.Shared.ResultRelated;
using Application.VehicleModels.Dtos;
using MediatR;

namespace Application.VehicleModels.Queries.CollectionVehicleBrandlessModelsQueryRelated;

internal sealed class CollectionVehicleBrandlessModelsQueryRequestHandler(IVehicleModelService vehicleModelService) : 
    IRequestHandler<CollectionVehicleBrandlessModelsQueryRequest, Result<PaginationResult<VehicleModelWithoutBrandNameDto>>>
{
    public async Task<Result<PaginationResult<VehicleModelWithoutBrandNameDto>>> Handle(
        CollectionVehicleBrandlessModelsQueryRequest request, CancellationToken cancellationToken)
    {
        var brands = await vehicleModelService.GetVehicleBrandlessModelCollection(request, cancellationToken);

        return Result<PaginationResult<VehicleModelWithoutBrandNameDto>>.Success(
            new PaginationResult<VehicleModelWithoutBrandNameDto>(brands, request.FilteringParameters.PageIndex));
    }
}