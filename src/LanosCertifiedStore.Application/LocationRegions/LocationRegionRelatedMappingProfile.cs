using AutoMapper;
using LanosCertifiedStore.Application.LocationRegions.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;

namespace LanosCertifiedStore.Application.LocationRegions;

internal sealed class LocationRegionRelatedMappingProfile : Profile
{
    public LocationRegionRelatedMappingProfile()
    {
        CreateMap<VehicleLocationRegion, LocationRegionDto>();
        CreateMap<VehicleLocationArea, LocationAreaDto>();
    }
}