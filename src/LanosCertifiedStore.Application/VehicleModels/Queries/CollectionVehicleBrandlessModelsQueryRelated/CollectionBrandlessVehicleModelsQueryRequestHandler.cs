using Application.Shared.ResultRelated;
using Application.VehicleModels.Dtos;
using MediatR;

namespace Application.VehicleModels.Queries.CollectionVehicleBrandlessModelsQueryRelated;

internal sealed class CollectionBrandlessVehicleModelsQueryRequestHandler(IVehicleModelService vehicleModelService) : 
    IRequestHandler<CollectionBrandlessVehicleModelsQueryRequest, Result<PaginationResult<VehicleModelWithoutBrandNameDto>>>
{
    public async Task<Result<PaginationResult<VehicleModelWithoutBrandNameDto>>> Handle(
        CollectionBrandlessVehicleModelsQueryRequest request, CancellationToken cancellationToken)
    {
        var brands = await vehicleModelService.GetVehicleBrandlessModelCollection(request, cancellationToken);

        return Result<PaginationResult<VehicleModelWithoutBrandNameDto>>.Success(
            new PaginationResult<VehicleModelWithoutBrandNameDto>(brands, request.FilteringParameters.PageIndex));
    }
}