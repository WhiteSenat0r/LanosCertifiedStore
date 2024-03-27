using Application.Dtos.Common;

namespace Application.Dtos.LocationDtos;

public sealed record RegionDto : VehicleAspectDto
{
    public ICollection<string>? RelatedAreas { get; init; }
    public ICollection<string>? RelatedTowns { get; init; }
}