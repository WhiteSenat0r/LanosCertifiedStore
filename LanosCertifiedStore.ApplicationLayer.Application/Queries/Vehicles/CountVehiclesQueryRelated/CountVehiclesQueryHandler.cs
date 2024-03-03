using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Vehicles.CountVehiclesQueryRelated;

internal sealed class CountVehiclesQueryHandler(IUnitOfWork unitOfWork) : 
    CountItemsQueryHandlerBase<Vehicle>(unitOfWork),
    IRequestHandler<CountVehiclesQuery, Result<ItemsCountDto>>
{
    public Task<Result<ItemsCountDto>> Handle(
        CountVehiclesQuery request, CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}