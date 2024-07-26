using AutoMapper;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

namespace LanosCertifiedStore.Application.VehicleTypes;

internal sealed class VehicleTypesRelatedMappingProfile : Profile
{
    public VehicleTypesRelatedMappingProfile()
    {
        CreateMap<VehicleType, VehicleTypeDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}