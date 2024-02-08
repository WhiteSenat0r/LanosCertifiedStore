using Application.Dtos.BrandDtos;
using Application.Dtos.ModelDtos;
using Application.Dtos.ColorDtos;
using Application.Dtos.TypeDtos;
using Application.Dtos.DisplacementDtos;
using Application.Dtos.PriceDtos;
using Application.Dtos.VehicleDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.MappingHelpers;

internal sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<VehicleBrand, BrandDto>();
        CreateMap<VehicleColor, ColorDto>();
        CreateMap<VehicleDisplacement, DisplacementDto>();
        CreateMap<VehicleModel, ModelDto>();
        CreateMap<VehicleType, TypeDto>();

        CreateMap<Vehicle, VehicleDto>()
            .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.Name))
            .ForMember(d => d.Type, o => o.MapFrom(s => s.Type.Name))
            .ForMember(d => d.Color, o => o.MapFrom(s => s.Color.Name))
            .ForMember(d => d.Model, o => o.MapFrom(s => s.Model.Name))
            .ForMember(d => d.Displacement, o => o.MapFrom(s => s.Displacement.Value));
        
        CreateMap<ActionVehicleDto, Vehicle>()
            .ForMember(d => d.BrandId, o => o.MapFrom(s => s.BrandId))
            .ForMember(d => d.TypeId, o => o.MapFrom(s => s.TypeId))
            .ForMember(d => d.ColorId, o => o.MapFrom(s => s.ColorId))
            .ForMember(d => d.ModelId, o => o.MapFrom(s => s.ModelId))
            .ForMember(d => d.DisplacementId, o => o.MapFrom(s => s.DisplacementId));

        CreateMap<VehiclePrice, PriceDto>();
    }
}