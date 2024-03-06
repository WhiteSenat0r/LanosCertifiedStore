using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Models.CountModelsQueryRelated;

internal sealed class CountModelsQueryHandler(IUnitOfWork unitOfWork) : 
    CountItemsQueryHandlerBase<VehicleModel>(unitOfWork),
    IRequestHandler<CountModelsQuery, Result<ItemsCountDto>>
{
    public Task<Result<ItemsCountDto>> Handle(
        CountModelsQuery request, CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}