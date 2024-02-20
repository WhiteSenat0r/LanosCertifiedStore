using Application.Core.Results;
using Application.Dtos.VehicleDtos;
using Application.RequestParams;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Vehicles.ListVehicles;

public sealed record ListVehiclesQuery(VehicleFilteringRequestParameters RequestParameters)
    : IRequest<Result<PaginationResult<VehicleDto>>>;