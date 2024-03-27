using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Persistence.DataModels.VehicleRelated.LocationRelated;
using Persistence.MappingHelpers.VehicleRelated.LocationRelated.Common.Classes;

namespace Persistence.MappingHelpers.VehicleRelated.LocationRelated;

public sealed class TownMappingProfile : LocationRelatedMappingProfileBase
{
    public TownMappingProfile()
    {
        AddMappingProfileFromModelToEntity();
        AddMappingProfileFromEntityToModel();
    }
    
    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<VehicleLocationTownDataModel, VehicleLocationTown>();

    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<VehicleLocationTown, VehicleLocationTownDataModel>()
            .ForMember(d => d.LocationAreaId, o => o.MapFrom(x => x.LocationArea.Id))
            .ForMember(d => d.LocationArea, o => o.Ignore())
            .ForMember(d => d.LocationRegionId, o => o.MapFrom(x => x.LocationRegion.Id))
            .ForMember(d => d.LocationRegion, o => o.Ignore());
}