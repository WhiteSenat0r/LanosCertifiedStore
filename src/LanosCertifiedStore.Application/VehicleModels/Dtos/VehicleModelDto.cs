using Application.Shared.DtosRelated;

namespace Application.VehicleModels.Dtos;

public sealed record VehicleModelDto : VehicleAspectDto
{
    public string VehicleBrand { get; init; }   
}