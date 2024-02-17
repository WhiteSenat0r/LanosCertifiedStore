using Application.Dtos.Common;

namespace Application.Dtos.ColorDtos;

public sealed record UpdateColorDto : UpdateVehicleAspectDto
{
    public string HexValue { get; set; } = null!;
}