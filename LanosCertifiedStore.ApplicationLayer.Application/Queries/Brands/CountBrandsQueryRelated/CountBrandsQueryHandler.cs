using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
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