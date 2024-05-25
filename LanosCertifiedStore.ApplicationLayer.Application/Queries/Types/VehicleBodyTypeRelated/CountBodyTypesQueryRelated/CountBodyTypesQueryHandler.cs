using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Queries.Types.VehicleEngineTypeRelated.CountEngineTypesQueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types.VehicleBodyTypeRelated.CountBodyTypesQueryRelated;

internal sealed class CountBodyTypesQueryHandler(IUnitOfWork unitOfWork) : 
    CountItemsQueryHandlerBase<VehicleEngineType>(unitOfWork),
    IRequestHandler<CountEngineTypesQuery, Result<ItemsCountDto>>
{
    public Task<Result<ItemsCountDto>> Handle(
        CountEngineTypesQuery request, CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}