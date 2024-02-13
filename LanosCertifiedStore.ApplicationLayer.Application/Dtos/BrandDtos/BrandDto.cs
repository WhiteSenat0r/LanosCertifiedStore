using Application.Dtos.Common;
using Application.Dtos.ModelDtos;

namespace Application.Dtos.BrandDtos;

public sealed class BrandDto : VehicleAspectDto
{
    public IEnumerable<ModelDto> Models { get; set; }
}