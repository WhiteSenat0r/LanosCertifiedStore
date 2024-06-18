using Application.Dtos.ColorDtos;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes;

namespace Application.MappingProfiles.DtoRelated;

public sealed class VehicleColorRelatedMappingProfile : Profile
{
    public VehicleColorRelatedMappingProfile()
    {
        CreateMap<VehicleColor, VehicleColorDto>();
    }
}