using AutoMapper;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.VehicleTypes;

internal sealed class VehicleTypesRelatedMappingProfile : Profile
{
    public VehicleTypesRelatedMappingProfile()
    {
        CreateMap<VehicleType, VehicleTypeDto>();
    }
}