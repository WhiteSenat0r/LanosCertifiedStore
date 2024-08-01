using LanosCertifiedStore.Application.Shared.RequestRelated;

namespace LanosCertifiedStore.Application.VehicleModels.Commands.CreateVehicleModelRelated;

public sealed record CreateVehicleModelCommandRequest(
    string Name,
    Guid BrandId,
    Guid TypeId,
    int MinimalProductionYear,
    int? MaximumProductionYear,
    IEnumerable<Guid> AvailableEngineTypesIds,
    IEnumerable<Guid> AvailableTransmissionTypesIds,
    IEnumerable<Guid> AvailableDrivetrainTypesIds,
    IEnumerable<Guid> AvailableBodyTypesIds) : ICommandRequest<Guid>;