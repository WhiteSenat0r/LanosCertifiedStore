using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels;

namespace Persistence.MappingHelpers;

internal sealed class VehicleDisplacementMappingProfile : Profile
{
    public VehicleDisplacementMappingProfile()
    {
        CreateMap<VehicleDisplacementDataModel, VehicleDisplacement>();
        CreateMap<VehicleDisplacement, VehicleDisplacementDataModel>();
    }
}