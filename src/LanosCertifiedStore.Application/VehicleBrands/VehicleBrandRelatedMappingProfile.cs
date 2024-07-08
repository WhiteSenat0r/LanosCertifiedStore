using Application.VehicleBrands.Dtos;
using AutoMapper;
using Domain.Entities.VehicleRelated;

namespace Application.VehicleBrands;

internal sealed class VehicleBrandRelatedMappingProfile : Profile
{
    public VehicleBrandRelatedMappingProfile()
    {
        CreateMap<VehicleBrand, VehicleBrandDto>();
        CreateMap<VehicleBrand, SingleVehicleBrandDto>();
    }
}