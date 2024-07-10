using AutoMapper;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.VehicleTypes;

internal sealed class VehicleTypesRelatedMappingProfile : Profile
{
    public VehicleTypesRelatedMappingProfile()
    {
        CreateMap<VehicleType, VehicleTypeDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}