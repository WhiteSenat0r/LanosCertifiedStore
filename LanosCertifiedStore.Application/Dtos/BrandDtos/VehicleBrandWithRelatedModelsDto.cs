using Application.Dtos.Common;
using Application.Dtos.ModelDtos;

namespace Application.Dtos.BrandDtos;

public sealed record VehicleBrandWithRelatedModelsDto : VehicleAspectDto
{
    public IEnumerable<ModelDto> Models { get; }
}