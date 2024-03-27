using Application.Dtos.Common;
using Application.Dtos.TypeDtos;

namespace Application.Dtos.ModelDtos;

public sealed record ModelDto : VehicleAspectDto
{
    public int? MinimalProductionYear { get; init; }
    public int? MaximumProductionYear { get; init; }
    public string? VehicleBrand { get; init; }
    public IEnumerable<VehicleTypeDto>? AvailableTypes { get; init; }
    public IEnumerable<VehicleBodyTypeDto>? AvailableBodyTypes { get; init; }
    public IEnumerable<VehicleEngineTypeDto>? AvailableEngineTypes { get; init; }
    public IEnumerable<VehicleDrivetrainTypeDto>? AvailableDrivetrainTypes { get; init; }
    public IEnumerable<VehicleTransmissionTypeDto>? AvailableTransmissionTypes { get; init; }
}