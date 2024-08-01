using AutoMapper;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

namespace LanosCertifiedStore.Application.VehicleBodyTypes;

internal sealed class VehicleBodyTypeRelatedMappingProfile : Profile
{
    public VehicleBodyTypeRelatedMappingProfile()
    {
        CreateMap<VehicleBodyType, VehicleBodyTypeDto>();
    }
}