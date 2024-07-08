using Application.LocationTowns.Dtos;
using Application.LocationTowns.Queries.LocationTownsRelated.CollectionLocationTownsQueryRequestRelated;
using Application.LocationTowns.Queries.LocationTownsRelated.CountLocationTownsQueryRelated;
using Application.Shared.DtosRelated;

namespace Application.LocationTowns;

public interface ILocationTownService
{
    Task<IReadOnlyCollection<LocationTownDto>> GetLocationTownCollection(
        CollectionLocationTownsQueryRequest request,
        CancellationToken cancellationToken);

    Task<ItemsCountDto> GetLocationTownsCount(
        CountLocationTownsQueryRequest request, CancellationToken cancellationToken);
}