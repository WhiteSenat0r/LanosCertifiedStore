using Application.Dtos.Common;

namespace Application.Dtos.LocationDtos;

public sealed record LocationAreaDto : VehicleAspectDto
{
    public string RelatedRegion { get; init; }
}