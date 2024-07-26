using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleModels.Dtos;
using MediatR;

namespace LanosCertifiedStore.Application.VehicleModels.Queries.CollectionVehicleBrandlessModelsQueryRelated;

internal sealed class CollectionBrandlessVehicleModelsQueryRequestHandler(IVehicleModelService vehicleModelService) :
    IRequestHandler<CollectionBrandlessVehicleModelsQueryRequest,
        Result<PaginationResult<VehicleModelWithoutBrandNameDto>>>
{
    public async Task<Result<PaginationResult<VehicleModelWithoutBrandNameDto>>> Handle(
        CollectionBrandlessVehicleModelsQueryRequest request, CancellationToken cancellationToken)
    {
        var brands = await vehicleModelService.GetVehicleBrandlessModelCollection(request, cancellationToken);

        var paginationResult = new PaginationResult<VehicleModelWithoutBrandNameDto>(
            brands,
            request.FilteringParameters.PageIndex);
        
        return paginationResult;
    }
}