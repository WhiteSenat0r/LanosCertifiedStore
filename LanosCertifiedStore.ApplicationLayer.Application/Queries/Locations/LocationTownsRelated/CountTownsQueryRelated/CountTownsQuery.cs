using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Locations.LocationTownsRelated.CountTownsQueryRelated;

public sealed record CountTownsQuery(IFilteringRequestParameters<VehicleLocationTown> RequestParameters) : 
    CountItemsQueryBase<VehicleLocationTown>(RequestParameters), IRequest<Result<ItemsCountDto>>;