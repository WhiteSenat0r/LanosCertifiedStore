using AutoMapper;
using Domain.Models.VehicleRelated.Classes;
using Persistence.DataModels.VehicleRelated;

namespace Persistence.MappingHelpers.VehicleRelated;

internal sealed class VehiclePriceMappingProfile : Profile
{
    public VehiclePriceMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }
    
    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<VehiclePriceDataModel, VehiclePrice>();

    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<VehiclePrice, VehiclePriceDataModel>()
            .ForMember(model => model.VehicleId, entity => entity.MapFrom(price => price.Vehicle.Id))
            .ForMember(model => model.Vehicle, options => options.Ignore());
}