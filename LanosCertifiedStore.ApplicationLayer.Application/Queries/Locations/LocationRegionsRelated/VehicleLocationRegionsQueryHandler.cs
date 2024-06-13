using Application.Contracts.RepositoryRelated.Common;
using Application.Core.Results;
using Application.Dtos.LocationDtos;
using Application.Queries.Common.QueryRelated;
using Application.Shared;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes.LocationRelated;
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