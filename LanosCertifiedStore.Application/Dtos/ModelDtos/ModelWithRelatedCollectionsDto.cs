using Application.Dtos.TypeDtos;

namespace Application.Dtos.ModelDtos;

public sealed record ModelWithRelatedCollectionsDto : ModelDto
{
    public IEnumerable<VehicleBodyTypeDto>? AvailableBodyTypes { get; init; }
    public IEnumerable<VehicleEngineTypeDto>? AvailableEngineTypes { get; init; }
    public IEnumerable<VehicleDrivetrainTypeDto>? AvailableDrivetrainTypes { get; init; }
    public IEnumerable<VehicleTransmissionTypeDto>? AvailableTransmissionTypes { get; init; }
}