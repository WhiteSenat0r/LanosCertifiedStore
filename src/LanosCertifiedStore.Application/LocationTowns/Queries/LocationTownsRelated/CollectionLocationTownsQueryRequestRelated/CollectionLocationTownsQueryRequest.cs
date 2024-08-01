using LanosCertifiedStore.Application.LocationTowns.Dtos;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;

namespace LanosCertifiedStore.Application.LocationTowns.Queries.LocationTownsRelated.CollectionLocationTownsQueryRequestRelated;

public sealed record CollectionLocationTownsQueryRequest(
    IFilteringRequestParameters<VehicleLocationTown> FilteringParameters)
    : ICollectionQueryRequest<VehicleLocationTown, PaginationResult<LocationTownDto>, LocationTownDto>;