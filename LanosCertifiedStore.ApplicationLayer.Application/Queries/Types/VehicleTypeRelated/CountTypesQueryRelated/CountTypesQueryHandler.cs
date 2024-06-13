using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Queries.Types.VehicleTypeRelated.CountTypesQueryRelated;

internal sealed class CountTypesQueryHandler(IUnitOfWork unitOfWork) : 
    CountItemsQueryHandlerBase<VehicleType>(unitOfWork),
    IRequestHandler<CountTypesQuery, Result<ItemsCountDto>>
{
    public Task<Result<ItemsCountDto>> Handle(
        CountTypesQuery request, CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}