using AutoMapper;
using Domain.Models.VehicleRelated.Classes;
using Persistence.DataModels.VehicleRelated;

namespace Persistence.MappingHelpers.VehicleRelated;

internal sealed class VehicleBrandMappingProfile : Profile
{
    public VehicleBrandMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }

    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<VehicleBrandDataModel, VehicleBrand>();

    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<VehicleBrand, VehicleBrandDataModel>()
            .ForMember(model => model.Models, options => options.Ignore());
}