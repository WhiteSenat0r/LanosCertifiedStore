using AutoMapper;
using Domain.Entities.VehicleRelated;

namespace Application.Images;

internal sealed class VehicleImageRelatedMappingProfile : Profile
{
    public VehicleImageRelatedMappingProfile()
    {
        CreateMap<VehicleImage, ImageDto>();
        CreateMap<ImageDto, VehicleImage>();
    }
}