using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleBrands.Dtos;
using MediatR;

namespace LanosCertifiedStore.Application.VehicleBrands.Queries.SingleVehicleBrandQueryRelated;

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
