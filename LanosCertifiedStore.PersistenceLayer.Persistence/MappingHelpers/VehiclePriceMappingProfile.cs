using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels;

namespace Persistence.MappingHelpers;

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
        CreateMap<VehiclePrice, VehiclePriceDataModel>();
}