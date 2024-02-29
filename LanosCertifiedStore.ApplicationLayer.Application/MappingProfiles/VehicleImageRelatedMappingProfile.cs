using Application.Dtos.ImageDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.MappingProfiles;

public class VehicleImageRelatedMappingProfile : Profile
{
    public VehicleImageRelatedMappingProfile()
    {
        CreateMap<VehicleImage, ImageDto>();
        CreateMap<ImageDto, VehicleImage>();
    }
}