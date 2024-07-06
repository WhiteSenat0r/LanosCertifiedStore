using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Core.Results;
using Application.Dtos.LocationDtos;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.QueryRequests.Locations.LocationAreasRelated.CollectionLocationAreasQueryRequestRelated;

public sealed record CollectionLocationAreasQueryRequest(
    IFilteringRequestParameters<VehicleLocationArea> FilteringParameters)
    : ICollectionQueryRequest<VehicleLocationArea, PaginationResult<LocationAreaDto>, LocationAreaDto>;