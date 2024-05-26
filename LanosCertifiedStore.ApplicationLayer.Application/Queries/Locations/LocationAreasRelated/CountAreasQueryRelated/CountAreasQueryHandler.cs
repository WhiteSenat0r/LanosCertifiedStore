using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Locations.LocationAreasRelated.CountAreasQueryRelated;

internal sealed class CountAreasQueryHandler(IUnitOfWork unitOfWork) : 
    CountItemsQueryHandlerBase<VehicleLocationArea>(unitOfWork),
    IRequestHandler<CountAreasQuery, Result<ItemsCountDto>>
{
    public Task<Result<ItemsCountDto>> Handle(
        CountAreasQuery request, CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}