using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Queries.CountVehiclesQueryRelated;

internal sealed class CountVehiclesQueryRequestHandler(
    IVehicleService vehicleService) : IRequestHandler<CountVehiclesQueryRequest, Result<ItemsCountDto>>
{
    public async Task<Result<ItemsCountDto>> Handle(
        CountVehiclesQueryRequest request,
        CancellationToken cancellationToken)
    {
        return await vehicleService.GetVehiclesCount(request, cancellationToken);
    }
}