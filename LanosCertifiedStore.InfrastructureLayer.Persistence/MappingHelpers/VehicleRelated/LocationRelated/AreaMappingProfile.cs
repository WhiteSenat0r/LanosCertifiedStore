using Domain.Models.VehicleRelated.Classes.LocationRelated;
using Persistence.DataModels.VehicleRelated.LocationRelated;
using Persistence.MappingHelpers.VehicleRelated.LocationRelated.Common.Classes;

namespace Persistence.MappingHelpers.VehicleRelated.LocationRelated;

public sealed class AreaMappingProfile : LocationRelatedMappingProfileBase
{
    public AreaMappingProfile()
    {
        AddMappingProfileFromModelToEntity();
        AddMappingProfileFromEntityToModel();
    }
    
    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<VehicleLocationAreaDataModel, VehicleLocationArea>();

    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<VehicleLocationRegion, VehicleLocationRegionDataModel>()
            .ForMember(d => d.RelatedAreas, o => o.MapFrom(x => MapObjectRange(x.RelatedAreas)))
            .ForMember(d => d.RelatedTowns, o => o.MapFrom(x => MapObjectRange(x.RelatedTowns)));
}