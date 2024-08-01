using AutoMapper;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

namespace LanosCertifiedStore.Application.VehicleDrivetrainTypes;

internal sealed class VehicleDrivetrainTypeRelatedMappingProfile : Profile
{
    public VehicleDrivetrainTypeRelatedMappingProfile()
    {
        CreateMap<VehicleDrivetrainType, VehicleDrivetrainTypeDto>();
    }
}