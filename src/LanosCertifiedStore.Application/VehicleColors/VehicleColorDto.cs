using Application.Shared.DtosRelated;

namespace Application.VehicleColors;

public sealed record VehicleColorDto(string HexValue) : VehicleAspectDto;