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

    private void AddMappingProfileFromEntityToModel()
    {
        CreateMap<VehicleType, VehicleTypeDataModel>()
            .ForMember(model => model.Id, entity => entity.MapFrom(type => type.Id))
            .ForMember(model => model.Name, entity => entity.MapFrom(type => type.Name));
    }
    
    private void AddMappingProfileFromModelToEntity()
    {
        CreateMap<VehicleBrandDataModel, VehicleBrand>()
            .ForMember(entity => entity.Id, model => model.MapFrom(type => type.Id))
            .ForMember(entity => entity.Name, model => model.MapFrom(type => type.Name));
    }
}