using Application.Dtos.Common;

namespace Application.Dtos.ColorDtos;

public sealed record VehicleColorDto : VehicleAspectDto
{
    public string? HexValue { get; set; }
}