using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes.LocationRelated;
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