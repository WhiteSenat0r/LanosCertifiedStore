using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using MediatR;

namespace Application.Queries.Locations.LocationRegionsRelated.CountRegionsQueryRelated;

public sealed record CountRegionsQuery(IFilteringRequestParameters<VehicleLocationRegion> RequestParameters) : 
    CountItemsQueryBase<VehicleLocationRegion>(RequestParameters), IRequest<Result<ItemsCountDto>>;