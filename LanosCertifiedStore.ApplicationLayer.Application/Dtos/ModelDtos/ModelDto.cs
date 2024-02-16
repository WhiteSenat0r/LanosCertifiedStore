using Application.Dtos.Common;

namespace Application.Dtos.ModelDtos;

public sealed record ModelDto : VehicleAspectDto
{
    public string? VehicleBrand { get; init; }
}