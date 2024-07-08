using Application.Dtos.LocationDtos;
using Application.QueryRequests.LocationsRelated.LocationRegionsRelated.CollectionLocationRegionsQueryRequestRelated;

namespace Application.Contracts.ServicesRelated.LocationRelated;

public interface ILocationRegionService
{
    Task<IReadOnlyCollection<LocationRegionDto>> GetLocationRegionCollection(
        CollectionLocationRegionsQueryRequest queryRequest,
        CancellationToken cancellationToken);
}