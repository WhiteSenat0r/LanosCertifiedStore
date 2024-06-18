using AutoMapper;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Persistence.Entities.VehicleRelated.TypeRelated;

namespace Persistence.MappingHelpers.VehicleRelated.TypeRelated;

internal sealed class VehicleBodyTypeMappingProfile : Profile
{
    public VehicleBodyTypeMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }

    private void AddMappingProfileFromEntityToModel() => 
        CreateMap<VehicleBodyType, VehicleBodyTypeEntity>();

    private void AddMappingProfileFromModelToEntity() => 
        CreateMap<VehicleBodyTypeEntity, VehicleBodyType>();
}