using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels;

namespace Persistence.MappingHelpers;

internal sealed class VehicleColorMappingProfile : Profile
{
    public VehicleColorMappingProfile()
    {
        CreateMap<VehicleColorDataModel, VehicleColor>();
        CreateMap<VehicleColor, VehicleColorDataModel>();
    }
}