using Application.Dtos.Common;
using Application.Dtos.LocationDtos;
using Application.QueryRequests.Locations.LocationAreasRelated.CollectionLocationAreasQueryRequestRelated;
using Application.QueryRequests.Locations.LocationAreasRelated.CountLocationAreasQueryRequestRelated;

namespace Application.Contracts.ServicesRelated.LocationRelated;

public interface ILocationAreaService
{
    Task<IReadOnlyCollection<LocationAreaDto>> GetLocationAreaCollection(
        CollectionLocationAreasQueryRequest queryRequest,
        CancellationToken cancellationToken);

    Task<ItemsCountDto> GetLocationAreasCount(
        CountLocationAreasQueryRequest queryRequest,
        CancellationToken cancellationToken);
}