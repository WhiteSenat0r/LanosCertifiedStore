using Application.LocationRegions.Dtos;
using AutoMapper;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.LocationRegions;

internal sealed class LocationRegionRelatedMappingProfile : Profile
{
    public LocationRegionRelatedMappingProfile()
    {
        CreateMap<VehicleLocationRegion, LocationRegionDto>();
        CreateMap<VehicleLocationArea, LocationAreaDto>();
    }
}