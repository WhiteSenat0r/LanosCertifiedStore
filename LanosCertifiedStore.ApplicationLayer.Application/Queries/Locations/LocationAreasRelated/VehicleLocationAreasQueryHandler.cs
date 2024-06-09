using Application.Core.Results;
using Application.Dtos.LocationDtos;
using Application.Queries.Common.QueryRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Locations.LocationAreasRelated;

internal sealed class VehicleLocationAreasQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    ListQueryHandlerBase<VehicleLocationArea, IFilteringRequestParameters<VehicleLocationArea>, AreaDto>(
        unitOfWork, mapper),
    IRequestHandler<VehicleLocationAreasQuery, Result<PaginationResult<AreaDto>>>
{
    public Task<Result<PaginationResult<AreaDto>>> Handle(VehicleLocationAreasQuery request,
        CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}