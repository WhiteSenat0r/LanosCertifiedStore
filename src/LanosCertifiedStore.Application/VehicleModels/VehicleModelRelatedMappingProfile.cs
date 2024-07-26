using AutoMapper;
using LanosCertifiedStore.Application.VehicleModels.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.VehicleModels;

internal sealed class VehicleModelRelatedMappingProfile : Profile
{
    public VehicleModelRelatedMappingProfile()
    {
        CreateMap<VehicleModel, VehicleModelWithoutBrandNameDto>();

        CreateMap<VehicleModel, VehicleModelDto>()
            .ForMember(d => d.VehicleBrand, o => o.MapFrom(s => s.VehicleBrand.Name));

        CreateMap<VehicleModel, SingleVehicleModelDto>()
            .ForMember(d => d.VehicleBrand, o => o.MapFrom(s => s.VehicleBrand.Name))
            .ForMember(d => d.VehicleType, o => o.MapFrom(s => s.VehicleType.Name))
            .ForMember(d => d.AvailableBodyTypes, o => o.MapFrom(s => s.AvailableBodyTypes))
            .ForMember(d => d.AvailableEngineTypes, o => o.MapFrom(s => s.AvailableEngineTypes))
            .ForMember(d => d.AvailableDrivetrainTypes, o => o.MapFrom(s => s.AvailableDrivetrainTypes))
            .ForMember(d => d.AvailableTransmissionTypes, o => o.MapFrom(s => s.AvailableTransmissionTypes));
    }
}