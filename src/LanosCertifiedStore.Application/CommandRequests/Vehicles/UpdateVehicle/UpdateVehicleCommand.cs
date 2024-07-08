using Application.CommandRequests.Vehicles.Common;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.Vehicles.UpdateVehicle;

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