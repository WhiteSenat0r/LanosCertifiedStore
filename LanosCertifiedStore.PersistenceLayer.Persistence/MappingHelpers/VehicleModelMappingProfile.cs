using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels;

namespace Persistence.MappingHelpers;

internal sealed class VehicleModelMappingProfile : Profile
{
    public VehicleModelMappingProfile()
    {
        CreateMap<VehicleModelDataModel, VehicleModel>();
        CreateMap<VehicleModel, VehicleModelDataModel>();
    }
}