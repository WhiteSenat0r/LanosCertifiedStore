using LanosCertifiedStore.Application.LocationRegions.Dtos;
using LanosCertifiedStore.Application.LocationRegions.Queries.CollectionLocationRegionsQueryRequestRelated;

namespace LanosCertifiedStore.Application.LocationRegions;

public interface ILocationRegionService
{
    Task<IReadOnlyCollection<LocationRegionDto>> GetLocationRegionCollection(
        CollectionLocationRegionsQueryRequest queryRequest,
        CancellationToken cancellationToken);
}