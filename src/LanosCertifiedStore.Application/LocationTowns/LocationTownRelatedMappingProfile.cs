using AutoMapper;
using LanosCertifiedStore.Application.LocationTowns.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;

namespace LanosCertifiedStore.Application.LocationTowns;

internal sealed class LocationTownRelatedMappingProfile : Profile
{
    public LocationTownRelatedMappingProfile()
    {
        CreateMap<VehicleLocationTown, LocationTownDto>()
            .ForMember(d => d.RelatedArea, o => o.MapFrom(x => x.LocationArea.Name))
            .ForMember(d => d.RelatedRegion, o => o.MapFrom(x => x.LocationRegion.Name))
            .ForMember(d => d.TownType, o => o.MapFrom(x => x.LocationTownType.Name));
    }
}