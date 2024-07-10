using Application.VehicleBrands.Dtos;
using AutoMapper;
using Domain.Entities.VehicleRelated;

namespace Application.VehicleBrands;

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