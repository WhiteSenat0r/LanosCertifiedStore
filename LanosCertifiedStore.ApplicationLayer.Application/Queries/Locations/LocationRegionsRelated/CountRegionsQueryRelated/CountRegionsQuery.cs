using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Locations.LocationRegionsRelated.CountRegionsQueryRelated;

public sealed record CountRegionsQuery(IFilteringRequestParameters<VehicleLocationRegion> RequestParameters) : 
    CountItemsQueryBase<VehicleLocationRegion>(RequestParameters), IRequest<Result<ItemsCountDto>>;