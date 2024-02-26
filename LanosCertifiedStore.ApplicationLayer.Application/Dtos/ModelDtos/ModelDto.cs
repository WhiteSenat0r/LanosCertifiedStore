using Application.Dtos.Common;
using Application.Dtos.TypeDtos;

namespace Application.Dtos.ModelDtos;

public sealed record ModelDto : VehicleAspectDto
{
    public string? VehicleBrand { get; init; }
    public IEnumerable<TypeDto>? AvailableTypes { get; init; }
}