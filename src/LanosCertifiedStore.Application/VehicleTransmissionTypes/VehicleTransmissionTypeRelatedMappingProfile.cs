using AutoMapper;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

namespace LanosCertifiedStore.Application.VehicleTransmissionTypes;

internal sealed class VehicleTransmissionTypeRelatedMappingProfile : Profile
{
    public VehicleTransmissionTypeRelatedMappingProfile()
    {
        CreateMap<VehicleTransmissionType, VehicleTransmissionTypeDto>();
    }
}