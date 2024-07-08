using Application.Dtos.LocationDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated.LocationRelated;

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
        CreateMap<VehicleLocationArea, LocationAreaDto>();
    }
    
    private void GetRegionInstanceMapping()
    {
        CreateMap<VehicleLocationRegion, LocationRegionDto>();
    }
    
    private void GetTownInstanceMapping()
    {
        CreateMap<VehicleLocationTown, TownDto>()
            .ForMember(d => d.RelatedArea, o => o.MapFrom(x => x.LocationArea.Name))
            .ForMember(d => d.RelatedRegion, o => o.MapFrom(x => x.LocationRegion.Name));
    }
}