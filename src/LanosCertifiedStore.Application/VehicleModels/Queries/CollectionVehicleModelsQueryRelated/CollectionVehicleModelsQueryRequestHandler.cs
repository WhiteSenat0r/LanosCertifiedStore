using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleModels.Dtos;
using MediatR;

namespace LanosCertifiedStore.Application.VehicleModels.Queries.CollectionVehicleModelsQueryRelated;

internal sealed class CollectionVehicleModelsQueryRequestHandler(IVehicleModelService vehicleModelService) : 
    IRequestHandler<CollectionVehicleModelsQueryRequest, Result<PaginationResult<VehicleModelDto>>>
{
    public async Task<Result<PaginationResult<VehicleModelDto>>> Handle(
        CollectionVehicleModelsQueryRequest request, CancellationToken cancellationToken)
    {
        var brands = await vehicleModelService.GetVehicleModelCollection(request, cancellationToken);

        var paginationResult = new PaginationResult<VehicleModelDto>(brands, request.FilteringParameters.PageIndex);
        
        return paginationResult;
    }
}