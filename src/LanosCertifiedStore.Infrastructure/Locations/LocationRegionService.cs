using LanosCertifiedStore.Application.LocationRegions;
using LanosCertifiedStore.Application.LocationRegions.Dtos;
using LanosCertifiedStore.Application.LocationRegions.Queries.CollectionLocationRegionsQueryRequestRelated;
using LanosCertifiedStore.Persistence.Queries.LocationRelated.LocationRegionRelated.QueryRelated;

namespace LanosCertifiedStore.Infrastructure.Services.Locations;

internal sealed class LocationRegionService(CollectionLocationRegionsQuery collectionQuery) : ILocationRegionService
{
    public async Task<IReadOnlyCollection<LocationRegionDto>> GetLocationRegionCollection(
        CollectionLocationRegionsQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await collectionQuery.Execute(queryRequest, cancellationToken);
    }
}