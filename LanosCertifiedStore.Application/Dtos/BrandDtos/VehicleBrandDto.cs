using Application.Dtos.Common;
using Application.Dtos.ModelDtos;

namespace Application.Dtos.BrandDtos;

public sealed record VehicleBrandDto : VehicleAspectDto
{
    public IEnumerable<ModelDto>? Models { get; init; }
}