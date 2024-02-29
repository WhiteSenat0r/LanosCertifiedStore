using Application.Dtos.ModelDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.MappingProfiles;

public class VehicleModelRelatedMappingProfile : Profile
{
    public VehicleModelRelatedMappingProfile()
    {
        CreateMap<VehicleModel, ModelDto>()
            .ForMember(d => d.VehicleBrand, o => o.MapFrom(s => s.Brand.Name))
            .ForMember(d => d.AvailableTypes, o => o.MapFrom(s => s.AvailableTypes));
    }
}