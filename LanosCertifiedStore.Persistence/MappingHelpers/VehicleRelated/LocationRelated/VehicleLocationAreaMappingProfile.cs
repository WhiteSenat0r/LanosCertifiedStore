using Domain.Models.VehicleRelated.Classes.LocationRelated;
using Persistence.Entities.VehicleRelated.LocationRelated;
using Persistence.MappingHelpers.VehicleRelated.LocationRelated.Common.Classes;

namespace Persistence.MappingHelpers.VehicleRelated.LocationRelated;

public sealed class VehicleLocationAreaMappingProfile : LocationRelatedMappingProfileBase
{
    public VehicleLocationAreaMappingProfile()
    {
        AddMappingProfileFromModelToEntity();
        AddMappingProfileFromEntityToModel();
    }
    
    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<VehicleLocationAreaEntity, VehicleLocationArea>();

    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<VehicleLocationRegion, VehicleLocationRegionEntity>()
            .ForMember(d => d.RelatedAreas, o => o.MapFrom(x => MapObjectRange(x.RelatedAreas)))
            .ForMember(d => d.RelatedTowns, o => o.MapFrom(x => MapObjectRange(x.RelatedTowns)));
}