using LanosCertifiedStore.Application.Shared.DtosRelated;

namespace LanosCertifiedStore.Application.VehicleModels.Dtos;

public sealed record VehicleModelDto : VehicleAspectDto
{
    public string VehicleBrand { get; init; }   
}