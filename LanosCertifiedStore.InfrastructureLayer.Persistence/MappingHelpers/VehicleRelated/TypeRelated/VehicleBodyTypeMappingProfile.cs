using AutoMapper;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.MappingHelpers.VehicleRelated.TypeRelated;

internal sealed class VehicleBodyTypeMappingProfile : Profile
{
    public VehicleBodyTypeMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }

    private void AddMappingProfileFromEntityToModel() => 
        CreateMap<VehicleBodyType, VehicleBodyTypeDataModel>();

    private void AddMappingProfileFromModelToEntity() => 
        CreateMap<VehicleBodyTypeDataModel, VehicleBodyType>();
}