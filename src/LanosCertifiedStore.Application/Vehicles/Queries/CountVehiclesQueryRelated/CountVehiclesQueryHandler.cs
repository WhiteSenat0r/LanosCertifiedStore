using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Queries.CountVehiclesQueryRelated;

internal sealed class CountVehiclesQueryHandler(IVehicleService vehicleService) :
    IRequestHandler<CountVehiclesQueryRequest, Result<ItemsCountDto>>
{
    public Task<Result<ItemsCountDto>> Handle(
        CountVehiclesQueryRequest request, CancellationToken cancellationToken) =>
        vehicleService.GetVehiclesCount(request, cancellationToken);
}