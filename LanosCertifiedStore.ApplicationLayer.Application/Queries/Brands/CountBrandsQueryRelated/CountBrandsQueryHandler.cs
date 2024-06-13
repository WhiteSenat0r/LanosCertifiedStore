using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Brands.CountBrandsQueryRelated;

internal sealed class CountBrandsQueryHandler(IUnitOfWork unitOfWork) : 
    CountItemsQueryHandlerBase<VehicleBrand>(unitOfWork),
    IRequestHandler<CountBrandsQuery, Result<ItemsCountDto>>
{
    public Task<Result<ItemsCountDto>> Handle(
        CountBrandsQuery request, CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}