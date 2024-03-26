using AutoMapper;
using Domain.Entities.IdentityRelated;
using Domain.Entities.UserRelated;
using Persistence.DataModels.IdentityRelated;

namespace Persistence.MappingHelpers.IdentityRelated;

internal sealed class RefreshTokenMappingProfile : Profile
{
    public RefreshTokenMappingProfile()
    {
        AddMappingProfileFromModelToEntity();
        AddMappingProfileFromEntityToModel();
    }

    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<RefreshTokenDataModel, RefreshToken>();

    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<User, RefreshToken>();
}