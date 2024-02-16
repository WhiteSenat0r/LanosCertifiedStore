using Application.Dtos.VehicleDtos;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Vehicles.UpdateVehicle;

public record UpdateVehicleCommand(ActionVehicleDto ActionVehicleDto) : IRequest<Result<Unit>>;