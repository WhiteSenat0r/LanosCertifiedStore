using AutoMapper;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.Images;

internal sealed class VehicleImageRelatedMappingProfile : Profile
{
    public VehicleImageRelatedMappingProfile()
    {
        CreateMap<VehicleImage, ImageDto>();
        CreateMap<ImageDto, VehicleImage>();
    }
}