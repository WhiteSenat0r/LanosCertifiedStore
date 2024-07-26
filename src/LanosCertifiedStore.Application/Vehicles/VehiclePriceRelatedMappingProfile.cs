using AutoMapper;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.Vehicles;

internal sealed class VehiclePriceRelatedMappingProfile : Profile
{
    public VehiclePriceRelatedMappingProfile()
    {
        CreateMap<VehiclePrice, PriceDto>();
    }
}