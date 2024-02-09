using Application.Core;
using Application.Dtos.VehicleDtos;
using Application.RequestParams;
using MediatR;

namespace Application.Queries.Vehicles.ListVehicles;

public sealed record ListVehiclesQuery(VehicleRequestParameters RequestParameters)
    : IRequest<Result<PaginationResult<VehicleDto>>>;