using Application.Dtos.BrandDtos;
using Application.Dtos.ModelDtos;
using Application.Dtos.ColorDtos;
using Application.Dtos.ImageDtos;
using Application.Dtos.TypeDtos;
using Application.Dtos.PriceDtos;
using Application.Dtos.VehicleDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.MappingHelpers;

internal sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Vehicle, Vehicle>()
            .ForMember(d => d.Images, opts => opts.Ignore())
            .ForMember(d => d.Prices, opts => opts.Ignore())
            .ForMember(d => d.Id, opts => opts.Ignore());
        
        CreateMap<Vehicle, UpdateVehicleDto>();
        CreateMap<VehicleBrand, BrandDto>();
        CreateMap<VehicleColor, ColorDto>();
        CreateMap<VehicleType, TypeDto>();
        CreateMap<VehiclePrice, PriceDto>();
        CreateMap<VehicleImage, ImageDto>();
        CreateMap<ImageDto, VehicleImage>();
        
        CreateMap<VehicleModel, ModelDto>()
            .ForMember(d => d.VehicleBrand, o => o.MapFrom(s => s.Brand.Name));

        CreateMap<Vehicle, VehicleDto>()
            .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.Name))
            .ForMember(d => d.Type, o => o.MapFrom(s => s.Type.Name))
            .ForMember(d => d.Color, o => o.MapFrom(s => s.Color.Name))
            .ForMember(d => d.Model, o => o.MapFrom(s => s.Model.Name));
    }
}