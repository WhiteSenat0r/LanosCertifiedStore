using AutoMapper;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.Vehicles;

internal sealed class VehicleRelatedMappingProfile : Profile
{
    public VehicleRelatedMappingProfile()
    {
        GetVehicleInstanceMapping();
        GetSingleVehicleDtoInstanceMapping();
        GetVehicleDtoInstanceMapping();
    }

    private void GetSingleVehicleDtoInstanceMapping()
    {
        CreateMap<Vehicle, SingleVehicleDto>()
            .ForMember(d => d.Brand, o => o.MapFrom(x => x.Brand.Name))
            .ForMember(d => d.Type, o => o.MapFrom(x => x.VehicleType.Name))
            .ForMember(d => d.Color, o => o.MapFrom(x => x.Color.Name))
            .ForMember(d => d.Model, o => o.MapFrom(x => x.Model.Name))
            .ForMember(d => d.BodyType, o => o.MapFrom(x => x.BodyType.Name))
            .ForMember(d => d.EngineType, o => o.MapFrom(x => x.EngineType.Name))
            .ForMember(d => d.TransmissionType, o => o.MapFrom(x => x.TransmissionType.Name))
            .ForMember(d => d.DrivetrainType, o => o.MapFrom(x => x.DrivetrainType.Name))
            .ForMember(d => d.Town, o => o.MapFrom(x => x.LocationTown.Name))
            .ForMember(d => d.Area, o => o.MapFrom(x => x.LocationTown.LocationArea.Name))
            .ForMember(d => d.Region, o => o.MapFrom(x => x.LocationTown.LocationRegion.Name));
    }

    private void GetVehicleInstanceMapping()
    {
        CreateMap<Vehicle, Vehicle>()
            .ForMember(d => d.Images, opts => opts.Ignore())
            .ForMember(d => d.Prices, opts => opts.Ignore())
            .ForMember(d => d.Id, opts => opts.Ignore());
    }

    private void GetVehicleDtoInstanceMapping()
    {
        CreateMap<Vehicle, VehicleDto>()
            .ForMember(d => d.Mileage, o => o.MapFrom(s => s.Mileage))
            .ForMember(d => d.Displacement, o => o.MapFrom(s => s.Displacement))
            .ForMember(d => d.Price, o => o.MapFrom(s => s.Prices.OrderByDescending(p => p.IssueDate).First().Value))
            .ForMember(d => d.MainImageUrl, o => o.MapFrom(s => s.Images.Count != 0
                ? s.Images.FirstOrDefault(i => i.IsMainImage)!.ImageUrl
                : null))
            .ForMember(d => d.FullName, o => o.MapFrom(s => $"{s.Brand.Name} {s.Model.Name} {s.ProductionYear}"))
            .ForMember(d => d.LocationTownName, o => o.MapFrom(s => s.LocationTown.Name))
            .ForMember(d => d.EngineType, o => o.MapFrom(s => s.EngineType.Name));
    }
}