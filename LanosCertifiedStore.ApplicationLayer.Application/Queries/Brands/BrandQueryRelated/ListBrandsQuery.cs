using Application.Core.Results;
using Application.Dtos.BrandDtos;
using Application.Queries.Common.QueryRelated;
using Application.RequestParams;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Brands.BrandQueryRelated;

public sealed record ListBrandsQuery(VehicleBrandFilteringRequestParameters RequestParameters) :
    ListQueryBase<VehicleBrand, VehicleBrandFilteringRequestParameters>(RequestParameters),
    IRequest<Result<PaginationResult<BrandDto>>>;