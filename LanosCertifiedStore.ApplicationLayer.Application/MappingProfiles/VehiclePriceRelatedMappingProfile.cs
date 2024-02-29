using Application.Dtos.PriceDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.MappingProfiles;

public class VehiclePriceRelatedMappingProfile : Profile
{
    public VehiclePriceRelatedMappingProfile()
    {
        CreateMap<VehiclePrice, PriceDto>();
    }
}