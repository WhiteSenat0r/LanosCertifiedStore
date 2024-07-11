using Application.Shared.ResultRelated;
using Application.VehicleBrands.Dtos;
using MediatR;

namespace Application.VehicleBrands.Queries.CollectionVehicleBrandsQueryRelated;

internal sealed class CollectionVehicleBrandsQueryRequestHandler(IVehicleBrandService vehicleBrandService) : 
    IRequestHandler<CollectionVehicleBrandsQueryRequest, Result<PaginationResult<VehicleBrandDto>>>
{
    public async Task<Result<PaginationResult<VehicleBrandDto>>> Handle(
        CollectionVehicleBrandsQueryRequest request, CancellationToken cancellationToken)
    {
        var brands = await vehicleBrandService.GetVehicleBrandCollection(request, cancellationToken);

        return Result<PaginationResult<VehicleBrandDto>>.Success(
            new PaginationResult<VehicleBrandDto>(brands, request.FilteringParameters.PageIndex));
    }
}