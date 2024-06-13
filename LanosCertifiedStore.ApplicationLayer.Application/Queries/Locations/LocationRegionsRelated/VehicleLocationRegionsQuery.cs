using Application.Contracts.RepositoryRelated.Common;
using Application.Core.Results;
using Application.Dtos.LocationDtos;
using Application.Queries.Common.QueryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes.LocationRelated;
using MediatR;

namespace Application.Queries.Locations.LocationRegionsRelated;

public sealed record VehicleLocationRegionsQuery(IFilteringRequestParameters<VehicleLocationRegion> RequestParameters) :
    ListQueryBase<VehicleLocationRegion, IFilteringRequestParameters<VehicleLocationRegion>>(RequestParameters),
    IRequest<Result<PaginationResult<RegionDto>>>;