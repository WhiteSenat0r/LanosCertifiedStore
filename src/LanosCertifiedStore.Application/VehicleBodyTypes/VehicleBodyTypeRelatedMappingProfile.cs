using AutoMapper;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.VehicleBodyTypes;

internal sealed class VehicleBodyTypeRelatedMappingProfile : Profile
{
    public VehicleBodyTypeRelatedMappingProfile()
    {
        CreateMap<VehicleBodyType, VehicleBodyTypeDto>();
    }
}