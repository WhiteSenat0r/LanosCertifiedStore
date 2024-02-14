using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels;

namespace Persistence.MappingHelpers;

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
        CreateMap<VehicleBrandDataModel, VehicleBrand>();
}