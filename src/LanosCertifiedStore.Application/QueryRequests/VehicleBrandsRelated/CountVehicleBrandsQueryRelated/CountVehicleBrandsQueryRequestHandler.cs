using Application.Contracts.ServicesRelated;
using Application.Dtos.Common;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.VehicleBrandsRelated.CountVehicleBrandsQueryRelated;

internal sealed class CountVehicleBrandsQueryRequestHandler(IVehicleBrandService vehicleBrandService) :
    IRequestHandler<CountVehicleBrandsQueryRequest, Result<ItemsCountDto>>
{
    public async Task<Result<ItemsCountDto>> Handle(
        CountVehicleBrandsQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await vehicleBrandService.GetVehicleBrandsCount(request, cancellationToken);

        return Result<ItemsCountDto>.Success(count);
    }
}