using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels.VehicleRelated;

namespace Persistence.MappingHelpers;

internal sealed class VehicleImageMappingProfile : Profile
{
    public VehicleImageMappingProfile()
    {
        AddMappingProfileFromEntityToModel();
        AddMappingProfileFromModelToEntity();
    }

    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<VehicleImage, VehicleImageDataModel>()
            .ForMember(model => model.VehicleId, entity => entity.MapFrom(image => image.Vehicle.Id))
            .ForMember(model => model.Vehicle, options => options.Ignore());

    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<VehicleImageDataModel, VehicleImage>();
}