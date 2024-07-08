using Application.Vehicles.Dtos;
using AutoMapper;
using Domain.Entities.VehicleRelated;

namespace Application.Vehicles;

public sealed class VehiclePriceRelatedMappingProfile : Profile
{
    public VehiclePriceRelatedMappingProfile()
    {
        CreateMap<VehiclePrice, PriceDto>();
    }
}