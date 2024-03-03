using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Colors.CountColorsQueryRelated;

internal sealed class CountColorsQueryHandler(IUnitOfWork unitOfWork) : 
    CountItemsQueryHandlerBase<VehicleColor>(unitOfWork),
    IRequestHandler<CountColorsQuery, Result<ItemsCountDto>>
{
    public Task<Result<ItemsCountDto>> Handle(
        CountColorsQuery request, CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}