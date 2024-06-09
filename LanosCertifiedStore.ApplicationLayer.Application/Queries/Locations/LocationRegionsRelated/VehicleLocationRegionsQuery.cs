using Application.Core.Results;
using Application.Dtos.LocationDtos;
using Application.Queries.Common.QueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Locations.LocationRegionsRelated;

public sealed record VehicleLocationRegionsQuery(IFilteringRequestParameters<VehicleLocationRegion> RequestParameters) :
    ListQueryBase<VehicleLocationRegion, IFilteringRequestParameters<VehicleLocationRegion>>(RequestParameters),
    IRequest<Result<PaginationResult<RegionDto>>>;