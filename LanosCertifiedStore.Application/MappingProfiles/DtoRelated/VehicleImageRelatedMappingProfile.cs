using Application.Dtos.ImageDtos;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes;

namespace Application.MappingProfiles.DtoRelated;

public sealed class VehicleImageRelatedMappingProfile : Profile
{
    public VehicleImageRelatedMappingProfile()
    {
        CreateMap<VehicleImage, ImageDto>();
        CreateMap<ImageDto, VehicleImage>();
    }
}