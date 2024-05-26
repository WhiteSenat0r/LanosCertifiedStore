using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Locations.LocationTownsRelated.CountAreasQueryRelated;

internal sealed class CountTownsQueryHandler(IUnitOfWork unitOfWork) : 
    CountItemsQueryHandlerBase<VehicleLocationTown>(unitOfWork),
    IRequestHandler<CountTownsQuery, Result<ItemsCountDto>>
{
    public Task<Result<ItemsCountDto>> Handle(
        CountTownsQuery request, CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}