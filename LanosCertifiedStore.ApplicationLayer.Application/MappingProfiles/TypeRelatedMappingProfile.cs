using Application.Dtos.TypeDtos;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes.TypeRelated;

namespace Application.MappingProfiles;

public sealed class TypeRelatedMappingProfile : Profile
{
    public TypeRelatedMappingProfile()
    {
        CreateMap<VehicleType, VehicleTypeDto>();
        CreateMap<VehicleEngineType, VehicleEngineTypeDto>();
        CreateMap<VehicleTransmissionType, VehicleTransmissionTypeDto>();
        CreateMap<VehicleDrivetrainType, VehicleDrivetrainTypeDto>();
        CreateMap<VehicleBodyType, VehicleBodyTypeDto>();
    }
}