using Application.Contracts.ServicesRelated;
using Application.Dtos.BrandDtos;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.VehicleBrandsRelated.SingleVehicleBrandQueryRelated;

internal sealed class SingleVehicleBrandQueryRequestHandler(IVehicleBrandService vehicleBrandService) : 
    IRequestHandler<SingleVehicleBrandQueryRequest, Result<SingleVehicleBrandDto>>
{
    public async Task<Result<SingleVehicleBrandDto>> Handle(
        SingleVehicleBrandQueryRequest request, CancellationToken cancellationToken)
    {
        var brand = await vehicleBrandService.GetSingleVehicleBrand(request, cancellationToken);

        return brand is null
            ? Result<SingleVehicleBrandDto>.Failure(Error.NotFound(request.ItemId))
            : Result<SingleVehicleBrandDto>.Success(brand);
    }
}
