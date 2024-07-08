using AutoMapper;
using Domain.Entities.VehicleRelated;

namespace Application.VehicleColors;

internal sealed class VehicleColorRelatedMappingProfile : Profile
{
    public VehicleColorRelatedMappingProfile()
    {
        CreateMap<VehicleColor, VehicleColorDto>();
    }
}