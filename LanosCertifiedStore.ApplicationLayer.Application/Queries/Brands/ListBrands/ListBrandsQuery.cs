using Application.Dtos.BrandDtos;
using Application.RequestParams;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Brands.ListBrands;

public sealed record ListBrandsQuery(VehicleBrandFilteringRequestParameters RequestParameters)
    : IRequest<Result<IReadOnlyList<BrandDto>>>;