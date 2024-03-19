using AutoMapper;
using Domain.Entities.VehicleRelated.Classes.TypesRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.MappingHelpers.VehicleRelated;

internal sealed class VehicleTypeMappingProfile : Profile
{
    public VehicleTypeMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }

    private void AddMappingProfileFromEntityToModel() => 
        CreateMap<VehicleType, VehicleTypeDataModel>();

    private void AddMappingProfileFromModelToEntity() => 
        CreateMap<VehicleTypeDataModel, VehicleType>();
}