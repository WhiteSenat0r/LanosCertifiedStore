using Application.Dtos.ColorDtos;
using Application.QueryRequests.VehicleColorsRelated.CollectionVehicleColorsQueryRequestRelated;

namespace Application.Contracts.ServicesRelated;

public interface IVehicleColorService
{
    Task<IReadOnlyCollection<VehicleColorDto>> GetVehicleColorCollection(
        CollectionVehicleColorsQueryRequest queryRequest, CancellationToken cancellationToken);
}