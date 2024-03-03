namespace Application.Commands.Vehicles.Common;

public interface IActionVehicleCommandBase
{
    Guid ModelId { get; }
    Guid TypeId { get; }
    Guid ColorId { get; }
    string Description { get; }
    double Displacement { get; }
    decimal Price { get; }
}