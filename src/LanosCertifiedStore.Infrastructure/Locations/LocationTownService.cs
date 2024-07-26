using LanosCertifiedStore.Application.LocationTowns;
using LanosCertifiedStore.Application.LocationTowns.Dtos;
using LanosCertifiedStore.Application.LocationTowns.Queries.LocationTownsRelated.CollectionLocationTownsQueryRequestRelated;
using LanosCertifiedStore.Application.LocationTowns.Queries.LocationTownsRelated.CountLocationTownsQueryRelated;
using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Persistence.Queries.LocationRelated.LocationTownRelated.QueryRelated;

namespace LanosCertifiedStore.Infrastructure.Services.Locations;

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