using LanosCertifiedStore.Application.Shared.RequestRelated;
using MediatR;

namespace LanosCertifiedStore.Application.VehicleModels.Commands.UpdateVehicleModelRelated;

public sealed record UpdateVehicleModelCommandRequest(
    Guid Id,
    int? MaximumProductionYear,
    IEnumerable<Guid> AvailableEngineTypesIds,
    IEnumerable<Guid> AvailableTransmissionTypesIds,
    IEnumerable<Guid> AvailableDrivetrainTypesIds,
    IEnumerable<Guid> AvailableBodyTypesIds) : ICommandRequest;