using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Queries.VehiclePriceRangeQueryRelated;

internal sealed class VehiclePriceRangeQueryRequestHandler(
    IVehicleService vehicleService) : IRequestHandler<VehiclePriceRangeQueryRequest, Result<PriceRangeDto>>
{
    public async Task<Result<PriceRangeDto>> Handle(
        VehiclePriceRangeQueryRequest request,
        CancellationToken cancellationToken)
    {
        return await vehicleService.GetPriceRange(request, cancellationToken);
    }
}