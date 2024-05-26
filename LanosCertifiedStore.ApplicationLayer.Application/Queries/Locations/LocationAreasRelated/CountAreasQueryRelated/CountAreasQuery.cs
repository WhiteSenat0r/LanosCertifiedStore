using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Locations.LocationAreasRelated.CountAreasQueryRelated;

public sealed record CountAreasQuery(IFilteringRequestParameters<VehicleLocationArea> RequestParameters) : 
    CountItemsQueryBase<VehicleLocationArea>(RequestParameters), IRequest<Result<ItemsCountDto>>;