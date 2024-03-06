using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Brands.CountBrandsQueryRelated;

public sealed record CountBrandsQuery(IFilteringRequestParameters<VehicleBrand> RequestParameters) : 
    CountItemsQueryBase<VehicleBrand>(RequestParameters), IRequest<Result<ItemsCountDto>>;