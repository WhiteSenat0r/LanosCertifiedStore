using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.VehicleBodyTypes;
using LanosCertifiedStore.Application.VehicleDrivetrainTypes;
using LanosCertifiedStore.Application.VehicleEngineTypes;
using LanosCertifiedStore.Application.VehicleTransmissionTypes;

namespace LanosCertifiedStore.Application.VehicleModels.Dtos;

public sealed record SingleVehicleModelDto : VehicleAspectDto
{
    public string VehicleBrand { get; init; } = null!;
    public int MinimalProductionYear { get; init; }
    public int? MaximumProductionYear { get; init; }
    public string VehicleType { get; init; } = null!;
    public IEnumerable<VehicleBodyTypeDto> AvailableBodyTypes { get; init; } = null!;
    public IEnumerable<VehicleEngineTypeDto> AvailableEngineTypes { get; init; } = null!;
    public IEnumerable<VehicleDrivetrainTypeDto> AvailableDrivetrainTypes { get; init; } = null!;
    public IEnumerable<VehicleTransmissionTypeDto> AvailableTransmissionTypes { get; init; } = null!;
}