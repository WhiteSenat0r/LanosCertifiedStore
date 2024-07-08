using Application.Contracts.ServicesRelated.LocationRelated;
using Application.Dtos.Common;
using Application.Dtos.LocationDtos;
using Application.QueryRequests.LocationsRelated.LocationTownsRelated.CollectionLocationTownsQueryRequestRelated;
using Application.QueryRequests.LocationsRelated.LocationTownsRelated.CountLocationTownsQueryRelated;
using Persistence.Queries.LocationRelated.LocationTownRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services.LocationRelated;

internal sealed class LocationTownService(
    CollectionLocationTownsQuery collectionQuery,
    CountLocationTownsQuery countQuery) : ILocationTownService
{
    public async Task<IReadOnlyCollection<LocationTownDto>> GetLocationTownCollection(
        CollectionLocationTownsQueryRequest request, CancellationToken cancellationToken)
    {
        return await collectionQuery.Execute(request, cancellationToken);
    }

    public async Task<ItemsCountDto> GetLocationTownsCount(
        CountLocationTownsQueryRequest request, CancellationToken cancellationToken)
    {
        return await countQuery.Execute(request, cancellationToken);
    }
}