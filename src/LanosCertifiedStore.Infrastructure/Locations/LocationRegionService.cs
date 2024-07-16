using Application.LocationRegions;
using Application.LocationRegions.Dtos;
using Application.LocationRegions.Queries.CollectionLocationRegionsQueryRequestRelated;
using Persistence.Queries.LocationRelated.LocationRegionRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Locations;

internal sealed class LocationRegionService(CollectionLocationRegionsQuery collectionQuery) : ILocationRegionService
{
    public async Task<IReadOnlyCollection<LocationRegionDto>> GetLocationRegionCollection(
        CollectionLocationRegionsQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await collectionQuery.Execute(queryRequest, cancellationToken);
    }
}