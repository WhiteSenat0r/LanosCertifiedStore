using Application.Vehicles.Dtos;
using AutoMapper;
using Domain.Entities.VehicleRelated;

namespace Application.Vehicles;

internal sealed class VehiclePriceRelatedMappingProfile : Profile
{
    public VehiclePriceRelatedMappingProfile()
    {
        CreateMap<VehiclePrice, PriceDto>();
    }
}