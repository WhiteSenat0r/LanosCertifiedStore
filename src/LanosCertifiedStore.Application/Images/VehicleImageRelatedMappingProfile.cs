using AutoMapper;
using Domain.Entities.VehicleRelated;

namespace Application.Images;

public sealed class VehicleImageRelatedMappingProfile : Profile
{
    public VehicleImageRelatedMappingProfile()
    {
        CreateMap<VehicleImage, ImageDto>();
        CreateMap<ImageDto, VehicleImage>();
    }
}