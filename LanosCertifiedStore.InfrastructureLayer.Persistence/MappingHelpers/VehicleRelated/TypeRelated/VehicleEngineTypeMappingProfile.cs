using AutoMapper;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.MappingHelpers.VehicleRelated.TypeRelated;

internal sealed class VehicleEngineTypeMappingProfile : Profile
{
    public VehicleEngineTypeMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }

    private void AddMappingProfileFromEntityToModel() => 
        CreateMap<VehicleEngineType, VehicleEngineTypeDataModel>();

    private void AddMappingProfileFromModelToEntity() => 
        CreateMap<VehicleEngineTypeDataModel, VehicleEngineType>();
}