using Application.Dtos.BrandDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated;

namespace Application.MappingProfiles;

public sealed class VehicleBrandRelatedMappingProfile : Profile
{
    public VehicleBrandRelatedMappingProfile()
    {
        CreateMap<VehicleBrand, VehicleBrandDto>();
        CreateMap<VehicleBrand, SingleVehicleBrandDto>();
    }
}