using Application.Dtos.ColorDtos;
using Application.Dtos.Common;
using Application.QueryRequests.VehicleColorsRelated.CollectionVehicleColorsQueryRequestRelated;
using Application.QueryRequests.VehicleColorsRelated.CountVehicleColorsQueryRequestRelated;

namespace Application.Contracts.ServicesRelated;

public interface IVehicleColorService
{
    Task<IReadOnlyCollection<VehicleColorDto>> GetVehicleColorCollection(
        CollectionVehicleColorsQueryRequest queryRequest, CancellationToken cancellationToken);

    Task<ItemsCountDto> GetVehicleColorsCount(
        CountVehicleColorsQueryRequest queryRequest, CancellationToken cancellationToken);
}