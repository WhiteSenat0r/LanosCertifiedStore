using Application.Dtos.VehicleDtos;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Vehicles.VehicleDetailsQueryRelated;

public sealed record VehicleDetailsQuery(Guid Id) : IRequest<Result<SingleVehicleDto>>;