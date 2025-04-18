using AutoMapper;
using LanosCertifiedStore.Application.Users.Dtos;
using LanosCertifiedStore.Domain.Entities.UserRelated;

namespace LanosCertifiedStore.Application.Users;

internal sealed class UserWishlistMappingProfile : Profile
{
    public UserWishlistMappingProfile()
    {
        CreateMap<UserWishlist, UserWishlistDto>();
    }
}