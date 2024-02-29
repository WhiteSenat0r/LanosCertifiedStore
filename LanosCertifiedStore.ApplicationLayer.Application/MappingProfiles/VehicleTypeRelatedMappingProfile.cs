using Application.Dtos.TypeDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.MappingProfiles;

public class VehicleTypeRelatedMappingProfile : Profile
{
    public VehicleTypeRelatedMappingProfile()
    {
        CreateMap<VehicleType, TypeDto>();
    }
}