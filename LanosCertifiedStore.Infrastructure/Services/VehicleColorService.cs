using Application.Contracts.ServicesRelated;
using Application.Dtos.ColorDtos;
using Application.Dtos.Common;
using Application.QueryRequests.Colors.CollectionVehicleColorsQueryRequestRelated;
using Application.QueryRequests.Colors.CountVehicleColorsQueryRequestRelated;
using Persistence.Queries.VehicleColorRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services;

internal sealed class VehicleColorService(
    CollectionVehicleColorsQuery collectionVehicleColorsQuery,
    CountVehicleColorsQuery countVehicleColorsQuery) : IVehicleColorService
{
    public async Task<IReadOnlyCollection<VehicleColorDto>> GetVehicleColors(
        CollectionVehicleColorsQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await collectionVehicleColorsQuery.Execute(queryRequest, cancellationToken);
    }

    public async Task<ItemsCountDto> GetVehicleColorsCount(CountVehicleColorsQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await countVehicleColorsQuery.Execute(queryRequest, cancellationToken);
    }
}