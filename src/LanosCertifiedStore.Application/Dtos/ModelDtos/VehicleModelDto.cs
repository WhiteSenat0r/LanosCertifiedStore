using Application.Dtos.Common;

namespace Application.Dtos.ModelDtos;

public sealed record VehicleModelDto : VehicleAspectDto
{
    public string VehicleBrand { get; init; }   
}