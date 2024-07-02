using Application.Dtos.Common;

namespace Application.Dtos.ModelDtos;

public record ModelDto : VehicleAspectDto
{
    public int? MinimalProductionYear { get; init; }
    public int? MaximumProductionYear { get; init; }
    public string? VehicleBrand { get; init; }
    public string? VehicleType { get; init; }
}