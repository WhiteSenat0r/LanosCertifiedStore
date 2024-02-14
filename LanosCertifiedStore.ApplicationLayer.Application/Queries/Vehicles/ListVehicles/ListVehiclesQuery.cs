using Application.Core;
using Application.Dtos.VehicleDtos;
using Application.RequestParams;
using Domain.Contracts.RequestParametersRelated;
using MediatR;

namespace Application.Queries.Vehicles.ListVehicles;

public sealed record ListVehiclesQuery(IVehicleFilteringRequestParameters RequestParameters)
    : IRequest<Result<PaginationResult<VehicleDto>>>;