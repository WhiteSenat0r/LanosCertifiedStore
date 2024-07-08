using Application.Dtos.Common;
using Application.Dtos.LocationDtos;
using Application.QueryRequests.LocationsRelated.LocationTownsRelated.CollectionLocationTownsQueryRequestRelated;
using Application.QueryRequests.LocationsRelated.LocationTownsRelated.CountLocationTownsQueryRelated;

namespace Application.Contracts.ServicesRelated.LocationRelated;

public interface ILocationTownService
{
    Task<IReadOnlyCollection<LocationTownDto>> GetLocationTownCollection(
        CollectionLocationTownsQueryRequest request,
        CancellationToken cancellationToken);

    Task<ItemsCountDto> GetLocationTownsCount(
        CountLocationTownsQueryRequest request, CancellationToken cancellationToken);
}