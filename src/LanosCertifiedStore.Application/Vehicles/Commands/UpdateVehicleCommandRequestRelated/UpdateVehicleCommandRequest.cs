using LanosCertifiedStore.Application.Shared.RequestRelated;

namespace LanosCertifiedStore.Application.Vehicles.Commands.UpdateVehicleCommandRequestRelated;

public record UpdateVehicleCommandRequest(
    Guid Id,
    Guid ColorId,
    Guid BodyTypeId,
    Guid EngineTypeId,
    Guid TransmissionTypeId,
    Guid DrivetrainTypeId,
    Guid LocationTownId,
    string Description,
    double Displacement,
    decimal Price,
    int ProductionYear,
    int Mileage) : ICommandRequest;