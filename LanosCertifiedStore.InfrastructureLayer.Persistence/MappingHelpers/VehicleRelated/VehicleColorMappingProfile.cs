using AutoMapper;
using Domain.Models.VehicleRelated.Classes;
using Persistence.Entities.VehicleRelated;

namespace Persistence.MappingHelpers.VehicleRelated;

internal sealed class VehicleColorMappingProfile : Profile
{
    public VehicleColorMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }
    
    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<VehicleColorEntity, VehicleColor>();
    
    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<VehicleColor, VehicleColorEntity>()
            .ForMember(model => model.Vehicles, options => options.Ignore());
}