using Application.Dtos.Common;

namespace Application.Dtos.ColorDtos;

public sealed record VehicleColorDto(string HexValue) : VehicleAspectDto;