using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles.Commands.Common;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Commands.UpdateVehicle;

public record UpdateVehicleCommand(
    Guid Id,
    Guid ModelId,
    Guid ColorId,
    Guid BodyTypeId,
    Guid EngineTypeId,
    Guid TransmissionTypeId,
    Guid DrivetrainTypeId,
    Guid LocationRegionId,
    Guid LocationAreaId,
    Guid LocationTownId,
    string Description,
    double Displacement,
    decimal Price,
    int ProductionYear,
    int Mileage) : IActionVehicleCommandBase, IRequest<Result<Unit>>;