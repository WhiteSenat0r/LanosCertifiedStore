using Application.VehicleColors;
using Application.VehicleColors.Queries.CollectionVehicleColorsQueryRequestRelated;
using Persistence.Queries.VehicleColorRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Vehicles;

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