using Application.Dtos.Common;

namespace Application.Dtos.LocationDtos;

public sealed record AreaDto : VehicleAspectDto
{
    public string? RelatedRegion { get; init; }
    public ICollection<string>? RelatedTowns { get; init; }
}