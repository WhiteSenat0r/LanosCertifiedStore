using AutoMapper;
using Domain.Entities.VehicleRelated;

namespace Application.VehicleColors;

public sealed class VehicleColorRelatedMappingProfile : Profile
{
    public VehicleColorRelatedMappingProfile()
    {
        CreateMap<VehicleColor, VehicleColorDto>();
    }
}