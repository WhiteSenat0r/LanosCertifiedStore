using AutoMapper;
using Domain.Models.VehicleRelated.Classes;
using Persistence.Entities.VehicleRelated;

namespace Persistence.MappingHelpers.VehicleRelated;

internal sealed class VehicleModelMappingProfile : Profile
{
    public VehicleModelMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }

    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<VehicleModel, VehicleModelEntity>()
            .ForMember(d => d.VehicleBrandId, o => o.MapFrom(s => s.Brand.Id))
            .ForMember(model => model.VehicleBrand, options => options.Ignore())
            .ForMember(d => d.VehicleTypeId, o => o.MapFrom(s => s.VehicleType.Id))
            .ForMember(model => model.VehicleType, options => options.Ignore());

    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<VehicleModelEntity, VehicleModel>()
            .ForMember(d => d.Brand, o => o.MapFrom(s => s.VehicleBrand));
}