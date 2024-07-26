using AutoMapper;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.VehicleColors;

internal sealed class VehicleColorRelatedMappingProfile : Profile
{
    public VehicleColorRelatedMappingProfile()
    {
        CreateMap<VehicleColor, VehicleColorDto>();
    }
}