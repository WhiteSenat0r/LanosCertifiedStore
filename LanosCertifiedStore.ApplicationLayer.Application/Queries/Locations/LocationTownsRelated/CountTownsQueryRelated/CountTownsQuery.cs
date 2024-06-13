using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes.LocationRelated;
using MediatR;

namespace Application.Queries.Locations.LocationTownsRelated.CountTownsQueryRelated;

public sealed record CountTownsQuery(IFilteringRequestParameters<VehicleLocationTown> RequestParameters) : 
    CountItemsQueryBase<VehicleLocationTown>(RequestParameters), IRequest<Result<ItemsCountDto>>;