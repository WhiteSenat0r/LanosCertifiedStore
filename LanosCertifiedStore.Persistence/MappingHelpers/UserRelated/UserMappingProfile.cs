using AutoMapper;
using Domain.Models.UserRelated;
using Persistence.Entities.UserRelated;

namespace Persistence.MappingHelpers.UserRelated;

internal sealed class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        AddMappingProfileFromModelToEntity();
        AddMappingProfileFromEntityToModel();
    }

    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<UserEntity, User>()
            .ForMember(d => d.Roles, o => o.MapFrom(s => s.Roles));

    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<User, UserEntity>();
}