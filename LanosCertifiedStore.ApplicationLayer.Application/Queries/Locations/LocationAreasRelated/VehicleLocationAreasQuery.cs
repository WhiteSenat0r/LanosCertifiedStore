using Application.Core.Results;
using Application.Dtos.LocationDtos;
using Application.Queries.Common.QueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Locations.LocationAreasRelated;

public sealed record VehicleLocationAreasQuery(IFilteringRequestParameters<VehicleLocationArea> RequestParameters) :
    ListQueryBase<VehicleLocationArea, IFilteringRequestParameters<VehicleLocationArea>>(RequestParameters),
    IRequest<Result<PaginationResult<AreaDto>>>;