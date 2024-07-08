using Application.CommandRequests.Vehicles.Common;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.Vehicles.CreateVehicle;

public record CreateVehicleCommand(
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
    int Mileage) : IActionVehicleCommandBase, IRequest<Result<Guid>>;