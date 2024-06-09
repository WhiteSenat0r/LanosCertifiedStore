using Application.Dtos.Common;

namespace Application.Dtos.LocationDtos;

public sealed record TownDto : VehicleAspectDto
{
    public string? RelatedRegion { get; init; }
    public string? RelatedArea { get; init; }
}