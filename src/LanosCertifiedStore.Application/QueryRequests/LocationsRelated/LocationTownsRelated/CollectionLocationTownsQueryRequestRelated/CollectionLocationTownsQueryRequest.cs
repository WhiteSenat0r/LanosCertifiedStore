using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.LocationDtos;
using Application.Shared.ResultRelated;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.QueryRequests.LocationsRelated.LocationTownsRelated.CollectionLocationTownsQueryRequestRelated;

public sealed record CollectionLocationTownsQueryRequest(
    IFilteringRequestParameters<VehicleLocationTown> FilteringParameters)
    : ICollectionQueryRequest<VehicleLocationTown, PaginationResult<LocationTownDto>, LocationTownDto>;