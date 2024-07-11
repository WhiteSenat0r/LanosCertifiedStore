using Application.Shared.RequestRelated;
using MediatR;

namespace Application.VehicleModels.Commands.UpdateVehicleModelRelated;

public sealed record UpdateVehicleModelCommandRequest(
    Guid Id,
    int? MaximumProductionYear,
    IEnumerable<Guid> AvailableEngineTypesIds,
    IEnumerable<Guid> AvailableTransmissionTypesIds,
    IEnumerable<Guid> AvailableDrivetrainTypesIds,
    IEnumerable<Guid> AvailableBodyTypesIds) : ICommandRequest<Unit>;