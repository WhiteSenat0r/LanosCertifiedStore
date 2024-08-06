using LanosCertifiedStore.Application.Shared.RequestRelated;

namespace LanosCertifiedStore.Application.Vehicles.Commands.CreateVehicleCommandRequestRelated;

public sealed record CreateVehicleCommandRequest(
    Guid BrandId,
    Guid ModelId,
    Guid VehicleTypeId,
    Guid BodyTypeId,
    Guid EngineTypeId,
    Guid TransmissionTypeId,
    Guid DrivetrainTypeId,
    Guid ColorId,
    Guid LocationTownId,
    string Description,
    double Displacement,
    decimal Price,
    int ProductionYear,
    int Mileage) : ICommandRequest<Guid>;