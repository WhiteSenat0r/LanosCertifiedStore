using AutoMapper;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Persistence.Entities.VehicleRelated.TypeRelated;

namespace Persistence.MappingHelpers.VehicleRelated.TypeRelated;

internal sealed class VehicleDrivetrainTypeMappingProfile : Profile
{
    public VehicleDrivetrainTypeMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }

    private void AddMappingProfileFromEntityToModel() => 
        CreateMap<VehicleDrivetrainType, VehicleDrivetrainTypeEntity>();

    private void AddMappingProfileFromModelToEntity() => 
        CreateMap<VehicleDrivetrainTypeEntity, VehicleDrivetrainType>();
}