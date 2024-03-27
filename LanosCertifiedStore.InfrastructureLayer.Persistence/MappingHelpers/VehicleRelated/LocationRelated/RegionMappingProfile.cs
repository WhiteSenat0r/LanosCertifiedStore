using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Persistence.DataModels.VehicleRelated.LocationRelated;
using Persistence.MappingHelpers.VehicleRelated.LocationRelated.Common.Classes;

namespace Persistence.MappingHelpers.VehicleRelated.LocationRelated;

public sealed class RegionMappingProfile : LocationRelatedMappingProfileBase
{
    public RegionMappingProfile()
    {
        AddMappingProfileFromModelToEntity();
        AddMappingProfileFromEntityToModel();
    }
    
    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<VehicleLocationRegionDataModel, VehicleLocationRegion>();

    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<VehicleLocationArea, VehicleLocationAreaDataModel>()
            .ForMember(d => d.LocationRegionId, o => o.MapFrom(x => x.LocationRegion.Id))
            .ForMember(d => d.LocationRegion, o => o.Ignore())
            .ForMember(d => d.RelatedTowns, o => o.MapFrom(x => MapObjectRange(x.RelatedTowns)));
}