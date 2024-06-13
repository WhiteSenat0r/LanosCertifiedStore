using Application.Dtos.IdentityDtos.AuthenticationDtos;
using Application.Dtos.IdentityDtos.ProfileDtos;
using AutoMapper;
using Domain.Models.UserRelated;

namespace Application.MappingProfiles;

public sealed class UserTypeRelatedMappingProfile : Profile
{
    public UserTypeRelatedMappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<User, ProfileDto>();
    }
}