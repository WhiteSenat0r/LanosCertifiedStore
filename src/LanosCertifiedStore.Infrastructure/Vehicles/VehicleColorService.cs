using LanosCertifiedStore.Application.VehicleColors;
using LanosCertifiedStore.Application.VehicleColors.Queries.CollectionVehicleColorsQueryRequestRelated;
using LanosCertifiedStore.Persistence.Queries.VehicleColorRelated.QueryRelated;

namespace LanosCertifiedStore.Infrastructure.Vehicles;

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