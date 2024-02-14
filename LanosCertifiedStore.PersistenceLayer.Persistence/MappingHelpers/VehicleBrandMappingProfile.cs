using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels;

namespace Persistence.MappingHelpers;

internal sealed class VehicleBrandMappingProfile : Profile
{
    public VehicleBrandMappingProfile()
    {
        CreateMap<VehicleBrand, VehicleBrandDataModel>();
        CreateMap<VehicleBrandDataModel, VehicleBrand>();
    }
}