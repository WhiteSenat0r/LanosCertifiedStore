using AutoMapper;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Persistence.Entities.VehicleRelated.TypeRelated;

namespace Persistence.MappingHelpers.VehicleRelated.TypeRelated;

internal sealed class VehicleEngineTypeMappingProfile : Profile
{
    public VehicleEngineTypeMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }

    private void AddMappingProfileFromEntityToModel() => 
        CreateMap<VehicleEngineType, VehicleEngineTypeEntity>();

    private void AddMappingProfileFromModelToEntity() => 
        CreateMap<VehicleEngineTypeEntity, VehicleEngineType>();
}