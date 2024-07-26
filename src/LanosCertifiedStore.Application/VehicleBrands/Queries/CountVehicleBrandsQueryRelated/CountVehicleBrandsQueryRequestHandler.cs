using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.VehicleBrands.Queries.CountVehicleBrandsQueryRelated;

internal sealed class CountVehicleBrandsQueryRequestHandler(IVehicleBrandService vehicleBrandService) :
    IRequestHandler<CountVehicleBrandsQueryRequest, Result<ItemsCountDto>>
{
    public async Task<Result<ItemsCountDto>> Handle(
        CountVehicleBrandsQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await vehicleBrandService.GetVehicleBrandsCount(request, cancellationToken);

        return count;
    }
}