using Application.Contracts.RepositoryRelated.Common;
using Application.Core.Results;
using Application.Dtos.BrandDtos;
using Application.Queries.Common.QueryRelated;
using Application.RequestParams;
using Application.Shared;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Brands.BrandQueryRelated;

// TODO
// internal sealed class ListBrandsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
//     ListQueryHandlerBase<VehicleBrand, VehicleBrandFilteringRequestParameters, BrandDto>(unitOfWork, mapper),
//     IRequestHandler<ListBrandsQuery, Result<PaginationResult<BrandDto>>>
// {
//     public Task<Result<PaginationResult<BrandDto>>> Handle(ListBrandsQuery request,
//         CancellationToken cancellationToken) =>
//         base.Handle(request, cancellationToken);
// }