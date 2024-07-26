using LanosCertifiedStore.Application.Shared.DtosRelated;

namespace LanosCertifiedStore.Application.VehicleColors;

public sealed record VehicleColorDto(string HexValue) : VehicleAspectDto;