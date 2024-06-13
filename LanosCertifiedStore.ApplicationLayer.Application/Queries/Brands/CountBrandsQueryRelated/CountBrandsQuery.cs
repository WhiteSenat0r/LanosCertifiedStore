using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Brands.CountBrandsQueryRelated;

public sealed record CountBrandsQuery(IFilteringRequestParameters<VehicleBrand> RequestParameters) : 
    CountItemsQueryBase<VehicleBrand>(RequestParameters), IRequest<Result<ItemsCountDto>>;