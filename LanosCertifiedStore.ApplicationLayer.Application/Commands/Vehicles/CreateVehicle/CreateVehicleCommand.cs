using Application.Commands.Vehicles.Common;

namespace Application.Commands.Vehicles.CreateVehicle;

public record CreateVehicleCommand(
    Guid ModelId,
    Guid TypeId,
    Guid ColorId,
    string Description,
    double Displacement,
    decimal Price)
    : IActionVehicleCommandBase;