using Application.Contracts.ServicesRelated;
using Application.Dtos.BrandDtos;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.VehicleBrandsRelated.SingleVehicleBrandQueryRelated;

internal sealed class SingleVehicleBrandQueryRequestHandler(IVehicleBrandService vehicleBrandService) :
    IRequestHandler<SingleVehicleBrandQueryRequest, Result<VehicleBrandWithRelatedModelsDto>>
{
    public async Task<Result<VehicleBrandWithRelatedModelsDto>> Handle(
        SingleVehicleBrandQueryRequest request, CancellationToken cancellationToken)
    {
        var vehicleBrand = await vehicleBrandService.GetSingleVehicleBrand(request, cancellationToken);

        return vehicleBrand is null
            ? Result<VehicleBrandWithRelatedModelsDto>.Failure(Error.NotFound(request.ItemId))
            : Result<VehicleBrandWithRelatedModelsDto>.Success(vehicleBrand);
    }
}