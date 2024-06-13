using Application.Dtos.ColorDtos;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes;

namespace Application.MappingProfiles;

public sealed class VehicleColorRelatedMappingProfile : Profile
{
    public VehicleColorRelatedMappingProfile()
    {
        CreateMap<VehicleColor, ColorDto>();
    }
}