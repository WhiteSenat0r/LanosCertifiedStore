using Application.Dtos.ImageDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated;

namespace Application.MappingProfiles;

public sealed class VehicleImageRelatedMappingProfile : Profile
{
    public VehicleImageRelatedMappingProfile()
    {
        CreateMap<VehicleImage, ImageDto>();
        CreateMap<ImageDto, VehicleImage>();
    }
}