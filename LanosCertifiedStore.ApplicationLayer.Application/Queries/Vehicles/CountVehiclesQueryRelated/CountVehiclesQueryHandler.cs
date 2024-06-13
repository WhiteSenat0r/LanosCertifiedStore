using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes;
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