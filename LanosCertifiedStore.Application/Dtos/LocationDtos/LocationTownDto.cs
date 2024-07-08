using Application.Dtos.Common;

namespace Application.Dtos.LocationDtos;

public sealed record LocationTownDto : VehicleAspectDto
{
    public string? RelatedRegion { get; init; }
    public string? RelatedArea { get; init; }
    public string? TownType { get; init; }
}