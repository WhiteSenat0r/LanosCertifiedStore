using Application.Dtos.VehicleDtos;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes;

namespace Application.MappingProfiles;

public sealed class VehicleRelatedMappingProfile : Profile
{
    public VehicleRelatedMappingProfile()
    {
        GetVehicleInstanceMapping();
        GetVehicleDtoInstanceMapping();
    }

    private void GetVehicleDtoInstanceMapping()
    {
        CreateMap<Vehicle, VehicleDto>()
            .ForMember(d => d.Brand, o => o.MapFrom(x => x.Brand.Name))
            .ForMember(d => d.Type, o => o.MapFrom(x => x.VehicleType.Name))
            .ForMember(d => d.Color, o => o.MapFrom(x => x.Color.Name))
            .ForMember(d => d.Model, o => o.MapFrom(x => x.Model.Name))
            .ForMember(d => d.BodyType, o => o.MapFrom(x => x.BodyType.Name))
            .ForMember(d => d.EngineType, o => o.MapFrom(x => x.EngineType.Name))
            .ForMember(d => d.TransmissionType, o => o.MapFrom(x => x.TransmissionType.Name))
            .ForMember(d => d.DrivetrainType, o => o.MapFrom(x => x.DrivetrainType.Name))
            .ForMember(d => d.Region, o => o.MapFrom(x => x.LocationRegion.Name))
            .ForMember(d => d.Area, o => o.MapFrom(x => x.LocationArea.Name))
            .ForMember(d => d.Town, o => o.MapFrom(x => x.LocationTown.Name));
    }

    private void GetVehicleInstanceMapping()
    {
        CreateMap<Vehicle, Vehicle>()
            .ForMember(d => d.Images, opts => opts.Ignore())
            .ForMember(d => d.Prices, opts => opts.Ignore())
            .ForMember(d => d.Id, opts => opts.Ignore());
    }
}