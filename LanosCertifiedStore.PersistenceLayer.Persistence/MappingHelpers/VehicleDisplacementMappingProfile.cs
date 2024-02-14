using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels;

namespace Persistence.MappingHelpers;

internal sealed class VehicleDisplacementMappingProfile : Profile
{
    public VehicleDisplacementMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }
    
    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<VehicleDisplacementDataModel, VehicleDisplacement>();
    
    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<VehicleDisplacement, VehicleDisplacementDataModel>();
}