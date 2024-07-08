using Application.LocationTowns.Dtos;
using AutoMapper;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.LocationTowns;

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