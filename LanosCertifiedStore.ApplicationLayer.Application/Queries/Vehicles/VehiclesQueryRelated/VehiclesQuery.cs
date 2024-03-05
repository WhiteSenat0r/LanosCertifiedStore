using Application.Core.Results;
using Application.Dtos.VehicleDtos;
using Application.Queries.Common.QueryRelated;
using Application.RequestParams;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Vehicles.VehiclesQueryRelated;

public sealed record VehiclesQuery(VehicleFilteringRequestParameters RequestParameters) : 
    ListQueryBase<Vehicle, VehicleFilteringRequestParameters>(RequestParameters), 
    IRequest<Result<PaginationResult<VehicleDto>>>;