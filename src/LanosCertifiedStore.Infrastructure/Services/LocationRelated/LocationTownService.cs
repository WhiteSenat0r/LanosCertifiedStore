using Application.LocationTowns;
using Application.LocationTowns.Dtos;
using Application.LocationTowns.Queries.LocationTownsRelated.CollectionLocationTownsQueryRequestRelated;
using Application.LocationTowns.Queries.LocationTownsRelated.CountLocationTownsQueryRelated;
using Application.Shared.DtosRelated;
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