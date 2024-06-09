using Application.Core.Results;
using Application.Dtos.LocationDtos;
using Application.Queries.Common.QueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Locations.LocationTownsRelated;

public sealed record VehicleLocationTownsQuery(IFilteringRequestParameters<VehicleLocationTown> RequestParameters) :
    ListQueryBase<VehicleLocationTown, IFilteringRequestParameters<VehicleLocationTown>>(RequestParameters),
    IRequest<Result<PaginationResult<TownDto>>>;