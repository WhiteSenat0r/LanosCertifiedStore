using Application.Dtos.ModelDtos;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes;

namespace Application.MappingProfiles;

public sealed class VehicleModelRelatedMappingProfile : Profile
{
    public VehicleModelRelatedMappingProfile()
    {
        CreateMap<VehicleModel, ModelDto>()
            .ForMember(d => d.VehicleBrand, o => o.MapFrom(s => s.Brand.Name))
            .ForMember(d => d.VehicleType, o => o.MapFrom(s => s.VehicleType.Name))
            .ForMember(d => d.AvailableBodyTypes, o => o.MapFrom(s => s.AvailableBodyTypes))
            .ForMember(d => d.AvailableEngineTypes, o => o.MapFrom(s => s.AvailableEngineTypes))
            .ForMember(d => d.AvailableDrivetrainTypes, o => o.MapFrom(s => s.AvailableDrivetrainTypes))
            .ForMember(d => d.AvailableTransmissionTypes, o => o.MapFrom(s => s.AvailableTransmissionTypes));
    }
}