using Application.Commands.Vehicles.Common;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Vehicles.UpdateVehicle;

public record UpdateVehicleCommand(
    Guid Id,
    Guid ModelId,
    Guid TypeId,
    Guid ColorId,
    string Description,
    double Displacement,
    decimal Price) : IActionVehicleCommandBase,  IRequest<Result<Unit>>;