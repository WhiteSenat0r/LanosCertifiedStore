using AutoMapper;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.MappingHelpers.VehicleRelated.TypeRelated;

internal sealed class VehicleDrivetrainTypeMappingProfile : Profile
{
    public VehicleDrivetrainTypeMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }

    private void AddMappingProfileFromEntityToModel() => 
        CreateMap<VehicleDrivetrainType, VehicleDrivetrainTypeDataModel>();

    private void AddMappingProfileFromModelToEntity() => 
        CreateMap<VehicleDrivetrainTypeDataModel, VehicleDrivetrainType>();
}