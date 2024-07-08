using Application.Dtos.PriceDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated;

namespace Application.MappingProfiles;

public sealed class VehiclePriceRelatedMappingProfile : Profile
{
    public VehiclePriceRelatedMappingProfile()
    {
        CreateMap<VehiclePrice, PriceDto>();
    }
}