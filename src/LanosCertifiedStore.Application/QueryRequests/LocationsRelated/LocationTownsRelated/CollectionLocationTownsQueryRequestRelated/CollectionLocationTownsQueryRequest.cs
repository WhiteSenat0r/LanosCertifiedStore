using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Core.Results;
using Application.Dtos.LocationDtos;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.QueryRequests.LocationsRelated.LocationTownsRelated.CollectionLocationTownsQueryRequestRelated;

public sealed record CollectionLocationTownsQueryRequest(
    IFilteringRequestParameters<VehicleLocationTown> FilteringParameters)
    : ICollectionQueryRequest<VehicleLocationTown, PaginationResult<LocationTownDto>, LocationTownDto>;