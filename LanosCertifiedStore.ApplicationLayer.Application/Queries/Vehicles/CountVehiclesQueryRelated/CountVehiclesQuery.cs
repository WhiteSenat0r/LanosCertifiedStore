using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Vehicles.CountVehiclesQueryRelated;

public sealed record CountVehiclesQuery(IFilteringRequestParameters<Vehicle> RequestParameters) : 
    CountItemsQueryBase<Vehicle>(RequestParameters), IRequest<Result<ItemsCountDto>>;