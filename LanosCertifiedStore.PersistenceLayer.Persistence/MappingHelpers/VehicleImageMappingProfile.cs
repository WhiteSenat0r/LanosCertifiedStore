using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels;

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
            .ForMember(d => d.Vehicle, o => o.MapFrom(s => s.Vehicle));
    
    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<VehicleImageDataModel, VehicleImage>()
            .ForMember(d => d.Vehicle, o => o.MapFrom(s => s.Vehicle));
}