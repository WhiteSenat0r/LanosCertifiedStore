using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.VehicleModels.Queries.CountVehicleModelsQueryRelated;

internal sealed class CountVehicleModelsQueryRequestHandler(IVehicleModelService vehicleModelService) :
    IRequestHandler<CountVehicleModelsQueryRequest, Result<ItemsCountDto>>
{
    public async Task<Result<ItemsCountDto>> Handle(
        CountVehicleModelsQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await vehicleModelService.GetVehicleModelsCount(request, cancellationToken);

        return count;
    }
}