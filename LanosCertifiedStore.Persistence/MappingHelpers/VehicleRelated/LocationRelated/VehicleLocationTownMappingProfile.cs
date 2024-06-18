using Domain.Models.VehicleRelated.Classes.LocationRelated;
using Persistence.Entities.VehicleRelated.LocationRelated;
using Persistence.MappingHelpers.VehicleRelated.LocationRelated.Common.Classes;

namespace Persistence.MappingHelpers.VehicleRelated.LocationRelated;

public sealed class VehicleLocationTownMappingProfile : LocationRelatedMappingProfileBase
{
    public VehicleLocationTownMappingProfile()
    {
        AddMappingProfileFromModelToEntity();
        AddMappingProfileFromEntityToModel();
    }
    
    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<VehicleLocationTownEntity, VehicleLocationTown>();

    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<VehicleLocationTown, VehicleLocationTownEntity>()
            .ForMember(d => d.LocationAreaId, o => o.MapFrom(x => x.LocationArea.Id))
            .ForMember(d => d.LocationArea, o => o.Ignore())
            .ForMember(d => d.LocationRegionId, o => o.MapFrom(x => x.LocationRegion.Id))
            .ForMember(d => d.LocationRegion, o => o.Ignore());
}