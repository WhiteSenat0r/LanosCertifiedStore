using Application.Core.Results;
using Application.Dtos.LocationDtos;
using Application.Queries.Common.QueryRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Locations.LocationTownsRelated;

internal sealed class VehicleLocationTownsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    ListQueryHandlerBase<VehicleLocationTown, IFilteringRequestParameters<VehicleLocationTown>, TownDto>(
        unitOfWork, mapper),
    IRequestHandler<VehicleLocationTownsQuery, Result<PaginationResult<TownDto>>>
{
    public Task<Result<PaginationResult<TownDto>>> Handle(VehicleLocationTownsQuery request,
        CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}