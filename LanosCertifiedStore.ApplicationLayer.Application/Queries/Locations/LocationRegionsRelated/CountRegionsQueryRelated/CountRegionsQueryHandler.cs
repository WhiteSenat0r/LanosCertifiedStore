using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Shared;
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