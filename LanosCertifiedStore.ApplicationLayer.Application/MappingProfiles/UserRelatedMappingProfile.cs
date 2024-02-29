using Application.Dtos.IdentityDtos.AuthenticationDtos;
using Application.Dtos.IdentityDtos.ProfileDtos;
using AutoMapper;
using Domain.Entities.UserRelated;

namespace Application.MappingProfiles;

public class UserTypeRelatedMappingProfile : Profile
{
    public UserTypeRelatedMappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<User, ProfileDto>();
    }
}