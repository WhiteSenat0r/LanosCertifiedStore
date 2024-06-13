using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using MediatR;

namespace Application.Queries.Locations.LocationRegionsRelated.CountRegionsQueryRelated;

internal sealed class CountRegionsQueryHandler(IUnitOfWork unitOfWork) : 
    CountItemsQueryHandlerBase<VehicleLocationRegion>(unitOfWork),
    IRequestHandler<CountRegionsQuery, Result<ItemsCountDto>>
{
    public Task<Result<ItemsCountDto>> Handle(
        CountRegionsQuery request, CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}