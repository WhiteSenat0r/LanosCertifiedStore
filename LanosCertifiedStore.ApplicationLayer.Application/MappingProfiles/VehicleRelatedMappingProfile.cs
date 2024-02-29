using Application.Dtos.VehicleDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.MappingProfiles;

public class VehicleRelatedMappingProfile : Profile
{
    public VehicleRelatedMappingProfile()
    {
        GetVehicleInstanceMapping();
        GetVehicleDtoInstanceMapping();
        GetSingleVehicleDtoInstanceMapping();
    }

    private void GetSingleVehicleDtoInstanceMapping()
    {
        CreateMap<Vehicle, SingleVehicleDto>()
            .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.Name))
            .ForMember(d => d.Type, o => o.MapFrom(s => s.Type.Name))
            .ForMember(d => d.Color, o => o.MapFrom(s => s.Color.Name))
            .ForMember(d => d.Model, o => o.MapFrom(s => s.Model.Name));
    }

    private void GetVehicleDtoInstanceMapping()
    {
        CreateMap<Vehicle, VehicleDto>()
            .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.Name))
            .ForMember(d => d.Type, o => o.MapFrom(s => s.Type.Name))
            .ForMember(d => d.Color, o => o.MapFrom(s => s.Color.Name))
            .ForMember(d => d.Model, o => o.MapFrom(s => s.Model.Name))
            .ForMember(d => d.Price, o => o.MapFrom(s => s.Prices.First()))
            .ForMember(d => d.Image, o => o.MapFrom(s => s.Images.First()));
    }

    private void GetVehicleInstanceMapping()
    {
        CreateMap<Vehicle, Vehicle>()
            .ForMember(d => d.Images, opts => opts.Ignore())
            .ForMember(d => d.Prices, opts => opts.Ignore())
            .ForMember(d => d.Id, opts => opts.Ignore());
    }
}