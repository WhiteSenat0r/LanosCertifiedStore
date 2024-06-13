using AutoMapper;
using Domain.Models.VehicleRelated.Classes;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Persistence.DataModels.VehicleRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;

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
            .ForMember(d => d.VehicleBrandId, o => o.MapFrom(s => s.Brand.Id))
            .ForMember(model => model.VehicleBrand, options => options.Ignore())
            .ForMember(d => d.VehicleTypeId, o => o.MapFrom(s => s.VehicleType.Id))
            .ForMember(model => model.VehicleType, options => options.Ignore());

    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<VehicleModelDataModel, VehicleModel>()
            .ForMember(d => d.Brand, o => o.MapFrom(s => s.VehicleBrand));
    
    private List<VehicleTypeDataModel> MapAvailableTypes(ICollection<VehicleType> availableTypes) => 
        availableTypes.Select(t => new VehicleTypeDataModel { Id = t.Id }).ToList();
}