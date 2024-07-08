using AutoMapper;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.VehicleDrivetrainTypes;

internal sealed class VehicleDrivetrainTypeRelatedMappingProfile : Profile
{
    public VehicleDrivetrainTypeRelatedMappingProfile()
    {
        CreateMap<VehicleDrivetrainType, VehicleDrivetrainTypeDto>();
    }
}