using Application.Core;
using Application.Dtos.VehicleDtos;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Vehicles.CreateVehicle;

public record CreateVehicleCommand(ActionVehicleDto ActionVehicleDto) : IRequest<Result<Unit>>;