using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels;

namespace Persistence.MappingHelpers;

internal sealed class VehicleMappingProfile : Profile
{
    public VehicleMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }
    
    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<VehicleDataModel, Vehicle>();
    
    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<Vehicle, VehicleDataModel>();
}