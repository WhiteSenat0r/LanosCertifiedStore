using Application.Contracts.RepositoryRelated.Common;
using Application.Core.Results;
using Application.Dtos.LocationDtos;
using Application.Queries.Common.QueryRelated;
using Application.Shared;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes.LocationRelated;
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