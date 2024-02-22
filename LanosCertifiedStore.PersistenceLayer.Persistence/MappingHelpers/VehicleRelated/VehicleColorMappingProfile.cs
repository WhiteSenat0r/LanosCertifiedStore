using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels.VehicleRelated;

namespace Persistence.MappingHelpers.VehicleRelated;

internal sealed class VehicleColorMappingProfile : Profile
{
    public VehicleColorMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }
    
    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<VehicleColorDataModel, VehicleColor>();
    
    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<VehicleColor, VehicleColorDataModel>();
}