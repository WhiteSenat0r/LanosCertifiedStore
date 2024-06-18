using AutoMapper;
using Domain.Models.VehicleRelated.Classes;
using Persistence.Entities.VehicleRelated;

namespace Persistence.MappingHelpers.VehicleRelated;

internal sealed class VehicleBrandMappingProfile : Profile
{
    public VehicleBrandMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }

    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<VehicleBrandEntity, VehicleBrand>();

    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<VehicleBrand, VehicleBrandEntity>()
            .ForMember(model => model.Models, options => options.Ignore());
}