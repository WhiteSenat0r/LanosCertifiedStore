using AutoMapper;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.MappingHelpers.VehicleRelated.TypeRelated;

internal sealed class VehicleTransmissionTypeMappingProfile : Profile
{
    public VehicleTransmissionTypeMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }

    private void AddMappingProfileFromEntityToModel() => 
        CreateMap<VehicleTransmissionType, VehicleTransmissionTypeDataModel>();

    private void AddMappingProfileFromModelToEntity() => 
        CreateMap<VehicleTransmissionTypeDataModel, VehicleTransmissionType>();
}