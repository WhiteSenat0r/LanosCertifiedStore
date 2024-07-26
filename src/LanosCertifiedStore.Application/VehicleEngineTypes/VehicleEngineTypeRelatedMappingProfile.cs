using AutoMapper;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

namespace LanosCertifiedStore.Application.VehicleEngineTypes;

internal sealed class VehicleEngineTypeRelatedMappingProfile : Profile
{
    public VehicleEngineTypeRelatedMappingProfile()
    {
        CreateMap<VehicleEngineType, VehicleEngineTypeDto>();
    }
}