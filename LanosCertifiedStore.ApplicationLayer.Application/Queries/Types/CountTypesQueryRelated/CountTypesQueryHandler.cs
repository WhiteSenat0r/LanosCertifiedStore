using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types.CountTypesQueryRelated;

internal sealed class CountTypesQueryHandler(IUnitOfWork unitOfWork) : 
    CountItemsQueryHandlerBase<VehicleType>(unitOfWork),
    IRequestHandler<CountTypesQuery, Result<ItemsCountDto>>
{
    public Task<Result<ItemsCountDto>> Handle(
        CountTypesQuery request, CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}