using AutoMapper;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.VehicleTransmissionTypes;

internal sealed class VehicleTransmissionTypeRelatedMappingProfile : Profile
{
    public VehicleTransmissionTypeRelatedMappingProfile()
    {
        CreateMap<VehicleTransmissionType, VehicleTransmissionTypeDto>();
    }
}