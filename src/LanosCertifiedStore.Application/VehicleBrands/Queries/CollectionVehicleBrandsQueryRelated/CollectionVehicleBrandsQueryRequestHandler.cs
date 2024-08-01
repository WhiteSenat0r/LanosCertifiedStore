using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleBrands.Dtos;
using MediatR;

namespace LanosCertifiedStore.Application.VehicleBrands.Queries.CollectionVehicleBrandsQueryRelated;

internal sealed class CollectionVehicleBrandsQueryRequestHandler(IVehicleBrandService vehicleBrandService) :
    IRequestHandler<CollectionVehicleBrandsQueryRequest, Result<PaginationResult<VehicleBrandDto>>>
{
    public async Task<Result<PaginationResult<VehicleBrandDto>>> Handle(
        CollectionVehicleBrandsQueryRequest request, CancellationToken cancellationToken)
    {
        var brands = await vehicleBrandService.GetVehicleBrandCollection(request, cancellationToken);

        var paginationResult = new PaginationResult<VehicleBrandDto>(brands, request.FilteringParameters.PageIndex);
        
        return paginationResult;
    }
}