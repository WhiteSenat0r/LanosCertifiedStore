using LanosCertifiedStore.Application.VehicleColors.Queries.CollectionVehicleColorsQueryRequestRelated;

namespace LanosCertifiedStore.Application.VehicleColors;

public interface IVehicleColorService
{
    Task<IReadOnlyCollection<VehicleColorDto>> GetVehicleColorCollection(
        CollectionVehicleColorsQueryRequest queryRequest, CancellationToken cancellationToken);
}