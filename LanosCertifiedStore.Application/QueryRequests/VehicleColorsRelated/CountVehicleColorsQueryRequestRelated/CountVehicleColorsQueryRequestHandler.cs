using Application.Contracts.ServicesRelated;
using Application.Dtos.Common;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.VehicleColorsRelated.CountVehicleColorsQueryRequestRelated;

internal sealed class CountVehicleColorsQueryRequestHandler(IVehicleColorService vehicleColorService)
    : IRequestHandler<CountVehicleColorsQueryRequest, Result<ItemsCountDto>>
{
    public async Task<Result<ItemsCountDto>> Handle(CountVehicleColorsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var itemsCountDto = await vehicleColorService.GetVehicleColorsCount(request, cancellationToken);

        return Result<ItemsCountDto>.Success(itemsCountDto);
    }
}