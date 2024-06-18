using AutoMapper;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Persistence.Entities.VehicleRelated.TypeRelated;

namespace Persistence.MappingHelpers.VehicleRelated.TypeRelated;

internal sealed class VehicleTransmissionTypeMappingProfile : Profile
{
    public VehicleTransmissionTypeMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }

    private void AddMappingProfileFromEntityToModel() => 
        CreateMap<VehicleTransmissionType, VehicleTransmissionTypeEntity>();

    private void AddMappingProfileFromModelToEntity() => 
        CreateMap<VehicleTransmissionTypeEntity, VehicleTransmissionType>();
}