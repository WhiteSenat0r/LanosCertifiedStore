using AutoMapper;
using LanosCertifiedStore.Application.VehicleBrands.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.VehicleBrands;

internal sealed class VehicleBrandRelatedMappingProfile : Profile
{
    public VehicleBrandRelatedMappingProfile()
    {
        CreateMap<VehicleBrand, VehicleBrandDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        CreateMap<VehicleBrand, SingleVehicleBrandDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}