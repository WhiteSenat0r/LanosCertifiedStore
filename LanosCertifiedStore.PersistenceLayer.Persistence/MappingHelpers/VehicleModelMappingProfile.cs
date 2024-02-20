using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels;

namespace Persistence.MappingHelpers;

internal sealed class VehicleModelMappingProfile : Profile
{
    public VehicleModelMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }
    
    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<VehicleModel, VehicleModelDataModel>()
            .ForMember(d => d.VehicleBrand, o => o.MapFrom(s => s.Brand.Name));
    
    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<VehicleModelDataModel, VehicleModel>()
            .ForMember(d => d.Brand, o => o.MapFrom(s => s.VehicleBrand));
}