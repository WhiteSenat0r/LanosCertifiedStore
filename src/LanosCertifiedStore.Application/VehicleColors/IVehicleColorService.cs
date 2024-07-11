using Application.VehicleColors.Queries.CollectionVehicleColorsQueryRequestRelated;

namespace Application.VehicleColors;

public interface IVehicleColorService
{
    Task<IReadOnlyCollection<VehicleColorDto>> GetVehicleColorCollection(
        CollectionVehicleColorsQueryRequest queryRequest, CancellationToken cancellationToken);
}