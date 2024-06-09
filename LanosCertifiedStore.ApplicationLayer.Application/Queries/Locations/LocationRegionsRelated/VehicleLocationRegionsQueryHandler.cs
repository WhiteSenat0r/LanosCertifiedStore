using Application.Core.Results;
using Application.Dtos.LocationDtos;
using Application.Queries.Common.QueryRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Locations.LocationRegionsRelated;

internal sealed class VehicleLocationRegionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    ListQueryHandlerBase<VehicleLocationRegion, IFilteringRequestParameters<VehicleLocationRegion>, RegionDto>(
        unitOfWork, mapper),
    IRequestHandler<VehicleLocationRegionsQuery, Result<PaginationResult<RegionDto>>>
{
    public Task<Result<PaginationResult<RegionDto>>> Handle(VehicleLocationRegionsQuery request,
        CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}