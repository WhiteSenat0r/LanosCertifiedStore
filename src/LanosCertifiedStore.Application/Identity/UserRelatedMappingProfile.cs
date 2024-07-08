using Application.Identity.Dtos.AuthenticationDtos;
using Application.Identity.Dtos.ProfileDtos;
using AutoMapper;
using Domain.Entities.UserRelated;

namespace Application.Identity;

public sealed class UserTypeRelatedMappingProfile : Profile
{
    public UserTypeRelatedMappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<User, ProfileDto>();
    }
}