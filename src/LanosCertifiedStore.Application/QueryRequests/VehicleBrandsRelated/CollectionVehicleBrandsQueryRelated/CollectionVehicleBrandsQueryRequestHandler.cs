using Application.Contracts.ServicesRelated;
using Application.Core.Results;
using Application.Dtos.BrandDtos;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.VehicleBrandsRelated.CollectionVehicleBrandsQueryRelated;

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