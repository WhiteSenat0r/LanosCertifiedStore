using AutoMapper;
using Domain.Models.IdentityRelated;
using Domain.Models.UserRelated;
using Persistence.Entities.IdentityRelated;

namespace Persistence.MappingHelpers.IdentityRelated;

internal sealed class RefreshTokenMappingProfile : Profile
{
    public RefreshTokenMappingProfile()
    {
        AddMappingProfileFromModelToEntity();
        AddMappingProfileFromEntityToModel();
    }

    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<RefreshTokenEntity, RefreshToken>();

    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<User, RefreshToken>();
}