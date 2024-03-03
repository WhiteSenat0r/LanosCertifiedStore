using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Vehicles.CountVehiclesQueryRelated;

public sealed record CountVehiclesQuery(IFilteringRequestParameters<Vehicle> RequestParameters) : 
    CountItemsQueryBase<Vehicle>(RequestParameters), IRequest<Result<ItemsCountDto>>;