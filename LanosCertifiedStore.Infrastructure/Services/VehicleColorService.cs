using Application.Contracts.ServicesRelated;
using Application.Dtos.ColorDtos;
using Application.QueryRequests.VehicleColorsRelated.CollectionVehicleColorsQueryRequestRelated;
using Persistence.Queries.VehicleColorRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services;

internal sealed class VehicleColorService(
    CollectionVehicleColorsQuery collectionVehicleColorsQuery) : IVehicleColorService
{
    public async Task<IReadOnlyCollection<VehicleColorDto>> GetVehicleColorCollection(
        CollectionVehicleColorsQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await collectionVehicleColorsQuery.Execute(queryRequest, cancellationToken);
    }
}