using Application.Dtos.ColorDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated;

namespace Application.MappingProfiles;

public sealed class VehicleColorRelatedMappingProfile : Profile
{
    public VehicleColorRelatedMappingProfile()
    {
        CreateMap<VehicleColor, VehicleColorDto>();
    }
}