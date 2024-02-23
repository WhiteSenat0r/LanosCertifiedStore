using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels.VehicleRelated;

namespace Persistence.MappingHelpers.VehicleRelated;

internal sealed class VehicleModelMappingProfile : Profile
{
    public VehicleModelMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }
    
    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<VehicleModel, VehicleModelDataModel>()
            .ForMember(d => d.VehicleBrand, o => o.MapFrom(s => s.Brand.Name))
            .ForMember(d => d.VehicleBrandId, o => o.MapFrom(s => s.Brand.Id))
            .ForMember(model => model.VehicleBrand, options => options.Ignore());
    
    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<VehicleModelDataModel, VehicleModel>()
            .ForMember(d => d.Brand, o => o.MapFrom(s => s.VehicleBrand));
}