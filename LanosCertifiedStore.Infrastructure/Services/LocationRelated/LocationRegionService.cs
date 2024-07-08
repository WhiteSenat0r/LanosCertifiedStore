using Application.Contracts.ServicesRelated.LocationRelated;
using Application.Dtos.LocationDtos;
using Application.QueryRequests.LocationsRelated.LocationRegionsRelated.CollectionLocationRegionsQueryRequestRelated;
using Persistence.Queries.LocationRelated.LocationRegionRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services.LocationRelated;

internal sealed class LocationRegionService(CollectionLocationRegionsQuery collectionQuery) : ILocationRegionService
{
    public async Task<IReadOnlyCollection<LocationRegionDto>> GetLocationRegionCollection(
        CollectionLocationRegionsQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await collectionQuery.Execute(queryRequest, cancellationToken);
    }
}