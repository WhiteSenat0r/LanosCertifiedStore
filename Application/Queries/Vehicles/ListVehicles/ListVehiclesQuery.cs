using Application.Core;
using Application.Dtos.VehicleDtos;
using MediatR;

namespace Application.Queries.Vehicles.ListVehicles;

public sealed record ListVehiclesQuery : IRequest<Result<IReadOnlyList<VehicleDto>>>;