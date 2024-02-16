using Application.Dtos.VehicleDtos;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Vehicles.VehicleDetails;

public sealed record VehicleDetailsQuery(Guid Id) : IRequest<Result<VehicleDto>>;