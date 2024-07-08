using Application.Shared.DtosRelated;

namespace Application.LocationTowns.Dtos;

public sealed record LocationTownDto : VehicleAspectDto
{
    public string? RelatedRegion { get; init; }
    public string? RelatedArea { get; init; }
    public string? TownType { get; init; }
}