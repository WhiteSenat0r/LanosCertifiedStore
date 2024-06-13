using AutoMapper;
using Domain.Models.VehicleRelated.Classes;
using Persistence.DataModels.VehicleRelated;

namespace Persistence.MappingHelpers.VehicleRelated;

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
        CreateMap<Vehicle, VehicleDataModel>()
            .ForMember(model => model.BrandId, entity => entity.MapFrom(vehicle => vehicle.Brand.Id))
            .ForMember(model => model.ModelId, entity => entity.MapFrom(vehicle => vehicle.Model.Id))
            .ForMember(model => model.ColorId, entity => entity.MapFrom(vehicle => vehicle.Color.Id))
            .ForMember(model => model.VehicleTypeId, entity => entity.MapFrom(vehicle => vehicle.VehicleType.Id))
            .ForMember(model => model.Brand, options => options.Ignore())
            .ForMember(model => model.Model, options => options.Ignore())
            .ForMember(model => model.Color, options => options.Ignore())
            .ForMember(model => model.VehicleType, options => options.Ignore());
}