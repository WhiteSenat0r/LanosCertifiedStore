using Application.LocationRegions.Dtos;
using Application.LocationRegions.Queries.CollectionLocationRegionsQueryRequestRelated;

namespace Application.LocationRegions;

public interface ILocationRegionService
{
    Task<IReadOnlyCollection<LocationRegionDto>> GetLocationRegionCollection(
        CollectionLocationRegionsQueryRequest queryRequest,
        CancellationToken cancellationToken);
}