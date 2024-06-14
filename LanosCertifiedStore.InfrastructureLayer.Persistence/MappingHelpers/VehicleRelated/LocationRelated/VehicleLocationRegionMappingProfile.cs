using Domain.Models.VehicleRelated.Classes.LocationRelated;
using Persistence.Entities.VehicleRelated.LocationRelated;
using Persistence.MappingHelpers.VehicleRelated.LocationRelated.Common.Classes;

namespace Persistence.MappingHelpers.VehicleRelated.LocationRelated;

public sealed class VehicleLocationRegionMappingProfile : LocationRelatedMappingProfileBase
{
    public VehicleLocationRegionMappingProfile()
    {
        AddMappingProfileFromModelToEntity();
        AddMappingProfileFromEntityToModel();
    }
    
    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<VehicleLocationRegionEntity, VehicleLocationRegion>();

    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<VehicleLocationArea, VehicleLocationAreaEntity>()
            .ForMember(d => d.LocationRegionId, o => o.MapFrom(x => x.LocationRegion.Id))
            .ForMember(d => d.LocationRegion, o => o.Ignore())
            .ForMember(d => d.RelatedTowns, o => o.MapFrom(x => MapObjectRange(x.RelatedTowns)));
}