using Application.Dtos.ColorDtos;
using Application.Dtos.Common;
using Application.QueryRequests.Colors.CollectionVehicleColorsQueryRequestRelated;
using Application.QueryRequests.Colors.CountVehicleColorsQueryRequestRelated;

namespace Application.Contracts.ServicesRelated;

public interface IVehicleColorService
{
    Task<IReadOnlyCollection<VehicleColorDto>> GetVehicleColors(CollectionVehicleColorsQueryRequest queryRequest,
        CancellationToken cancellationToken);

    Task<ItemsCountDto> GetVehicleColorsCount(CountVehicleColorsQueryRequest queryRequest,
        CancellationToken cancellationToken);
}