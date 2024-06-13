using AutoMapper;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.MappingHelpers.VehicleRelated.TypeRelated;

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