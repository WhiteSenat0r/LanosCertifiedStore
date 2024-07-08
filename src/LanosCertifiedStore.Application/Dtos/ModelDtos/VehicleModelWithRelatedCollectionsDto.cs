using Application.Dtos.Common;
using Application.Dtos.TypeDtos;

namespace Application.Dtos.ModelDtos;

public sealed record VehicleModelWithRelatedCollectionsDto : VehicleAspectDto
{
    public int? MinimalProductionYear { get; init; }
    public int? MaximumProductionYear { get; init; }
    public string? VehicleBrand { get; init; }
    public string? VehicleType { get; init; }
    public IEnumerable<VehicleBodyTypeDto>? AvailableBodyTypes { get; init; }
    public IEnumerable<VehicleEngineTypeDto>? AvailableEngineTypes { get; init; }
    public IEnumerable<VehicleDrivetrainTypeDto>? AvailableDrivetrainTypes { get; init; }
    public IEnumerable<VehicleTransmissionTypeDto>? AvailableTransmissionTypes { get; init; }
}