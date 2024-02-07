using Application.Core;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Vehicles.CreateVehicle;

public record CreateVehicleCommand(Vehicle Vehicle) : IRequest<Result<Unit>>;