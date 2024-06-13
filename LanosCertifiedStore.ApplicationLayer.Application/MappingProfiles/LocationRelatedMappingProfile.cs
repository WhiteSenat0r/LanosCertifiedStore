using Application.Dtos.LocationDtos;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes.LocationRelated;

namespace Application.MappingProfiles;

public sealed class LocationRelatedMappingProfile : Profile
{
    public LocationRelatedMappingProfile()
    {
        GetAreaInstanceMapping();
        GetRegionInstanceMapping();
        GetTownInstanceMapping();
    }

    private void GetAreaInstanceMapping()
    {
        CreateMap<VehicleLocationArea, AreaDto>()
            .ForMember(d => d.RelatedRegion, o => o.MapFrom(x => x.LocationRegion.Name))
            .ForMember(d => d.RelatedTowns, o => o.MapFrom(x => x.RelatedTowns.Select(t => t.Name)));
    }
    
    private void GetRegionInstanceMapping()
    {
        CreateMap<VehicleLocationRegion, RegionDto>()
            .ForMember(d => d.RelatedAreas, o => o.MapFrom(x => x.RelatedAreas.Select(a => a.Name)))
            .ForMember(d => d.RelatedTowns, o => o.MapFrom(x => x.RelatedTowns.Select(t => t.Name)));
    }
    
    private void GetTownInstanceMapping()
    {
        CreateMap<VehicleLocationTown, TownDto>()
            .ForMember(d => d.RelatedArea, o => o.MapFrom(x => x.LocationArea.Name))
            .ForMember(d => d.RelatedRegion, o => o.MapFrom(x => x.LocationRegion.Name));
    }
}