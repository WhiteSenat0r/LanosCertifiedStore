using Application.LocationTowns.Dtos;
using Application.Shared.RequestParamsRelated;
using Application.Shared.RequestRelated.QueryRelated;
using Application.Shared.ResultRelated;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.LocationTowns.Queries.LocationTownsRelated.CollectionLocationTownsQueryRequestRelated;

public sealed record CollectionLocationTownsQueryRequest(
    IFilteringRequestParameters<VehicleLocationTown> FilteringParameters)
    : ICollectionQueryRequest<VehicleLocationTown, PaginationResult<LocationTownDto>, LocationTownDto>;