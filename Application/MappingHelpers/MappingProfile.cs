using Application.Dtos.BrandDtos;
using Application.Dtos.ModelDtos;
using Application.Dtos.ColorDtos;
using Application.Dtos.TypeDtos;
using Application.Dtos.DisplacementDtos;
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
    }
}