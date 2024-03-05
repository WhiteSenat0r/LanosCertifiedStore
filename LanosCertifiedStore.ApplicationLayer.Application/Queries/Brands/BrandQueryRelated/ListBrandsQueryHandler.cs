using Application.Core.Results;
using Application.Dtos.BrandDtos;
using Application.Queries.Common.QueryRelated;
using Application.RequestParams;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Brands.BrandQueryRelated;

internal sealed class ListBrandsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    ListQueryHandlerBase<VehicleBrand, VehicleBrandFilteringRequestParameters, BrandDto>(unitOfWork, mapper),
    IRequestHandler<ListBrandsQuery, Result<PaginationResult<BrandDto>>>
{
    public Task<Result<PaginationResult<BrandDto>>> Handle(ListBrandsQuery request,
        CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}