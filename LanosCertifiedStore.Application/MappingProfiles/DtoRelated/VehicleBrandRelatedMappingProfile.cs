using Application.Dtos.BrandDtos;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes;

namespace Application.MappingProfiles.DtoRelated;

public sealed class VehicleBrandRelatedMappingProfile : Profile
{
    public VehicleBrandRelatedMappingProfile()
    {
        CreateMap<VehicleBrand, VehicleBrandDto>();
    }
}