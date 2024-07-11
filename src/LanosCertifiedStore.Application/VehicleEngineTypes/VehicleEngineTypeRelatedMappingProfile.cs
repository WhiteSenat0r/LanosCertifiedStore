using AutoMapper;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.VehicleEngineTypes;

internal sealed class VehicleEngineTypeRelatedMappingProfile : Profile
{
    public VehicleEngineTypeRelatedMappingProfile()
    {
        CreateMap<VehicleEngineType, VehicleEngineTypeDto>();
    }
}