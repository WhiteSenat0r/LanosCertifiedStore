using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes.LocationRelated;
using MediatR;

namespace Application.Queries.Locations.LocationAreasRelated.CountAreasQueryRelated;

public sealed record CountAreasQuery(IFilteringRequestParameters<VehicleLocationArea> RequestParameters) : 
    CountItemsQueryBase<VehicleLocationArea>(RequestParameters), IRequest<Result<ItemsCountDto>>;