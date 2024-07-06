using Application.Contracts.ServicesRelated.LocationRelated;
using Application.Dtos.Common;
using Application.Dtos.LocationDtos;
using Application.QueryRequests.Locations.LocationAreasRelated.CollectionLocationAreasQueryRequestRelated;
using Application.QueryRequests.Locations.LocationAreasRelated.CountLocationAreasQueryRequestRelated;
using Persistence.Queries.LocationRelated.LocationAreaRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services.LocationRelated;

internal sealed class LocationAreaService(
    CollectionLocationAreasQuery collectionLocationAreasQuery,
    CountLocationAreasQuery countLocationAreasQuery) : ILocationAreaService
{
    public async Task<IReadOnlyCollection<LocationAreaDto>> GetLocationAreaCollection(
        CollectionLocationAreasQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await collectionLocationAreasQuery.Execute(queryRequest, cancellationToken);
    }

    public async Task<ItemsCountDto> GetLocationAreasCount(
        CountLocationAreasQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await countLocationAreasQuery.Execute(queryRequest, cancellationToken);
    }
}