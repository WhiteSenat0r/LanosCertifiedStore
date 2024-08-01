using LanosCertifiedStore.Application.LocationTowns.Dtos;
using LanosCertifiedStore.Application.LocationTowns.Queries.LocationTownsRelated.CollectionLocationTownsQueryRequestRelated;
using LanosCertifiedStore.Application.LocationTowns.Queries.LocationTownsRelated.CountLocationTownsQueryRelated;
using LanosCertifiedStore.Application.Shared.DtosRelated;

namespace LanosCertifiedStore.Application.LocationTowns;

public interface ILocationTownService
{
    Task<IReadOnlyCollection<LocationTownDto>> GetLocationTownCollection(
        CollectionLocationTownsQueryRequest request,
        CancellationToken cancellationToken);

    Task<ItemsCountDto> GetLocationTownsCount(
        CountLocationTownsQueryRequest request, CancellationToken cancellationToken);
}