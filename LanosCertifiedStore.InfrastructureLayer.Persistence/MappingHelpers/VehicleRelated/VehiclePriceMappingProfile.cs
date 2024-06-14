using AutoMapper;
using Domain.Models.VehicleRelated.Classes;
using Persistence.Entities.VehicleRelated;

namespace Persistence.MappingHelpers.VehicleRelated;

internal sealed class VehiclePriceMappingProfile : Profile
{
    public VehiclePriceMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }
    
    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<VehiclePriceEntity, VehiclePrice>();

    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<VehiclePrice, VehiclePriceEntity>()
            .ForMember(model => model.VehicleId, entity => entity.MapFrom(price => price.Vehicle.Id))
            .ForMember(model => model.Vehicle, options => options.Ignore());
}