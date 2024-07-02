namespace Application.CommandRequests.Vehicles.Common;

public interface IActionVehicleCommandBase
{
    Guid ModelId { get; }
    Guid ColorId { get; }
    Guid BodyTypeId { get; }
    Guid EngineTypeId { get; }
    Guid TransmissionTypeId { get; }
    Guid DrivetrainTypeId { get; }
    Guid LocationRegionId { get; }
    Guid LocationAreaId { get; }
    Guid LocationTownId { get; }
    string Description { get; }
    double Displacement { get; }
    decimal Price { get; }
    int ProductionYear { get; }
    int Mileage { get; }
}