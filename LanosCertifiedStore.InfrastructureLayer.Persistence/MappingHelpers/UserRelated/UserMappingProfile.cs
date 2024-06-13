using AutoMapper;
using Domain.Models.UserRelated;
using Persistence.DataModels.UserRelated;

namespace Persistence.MappingHelpers.UserRelated;

internal sealed class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        AddMappingProfileFromModelToEntity();
        AddMappingProfileFromEntityToModel();
    }

    private void AddMappingProfileFromModelToEntity() =>
        CreateMap<UserDataModel, User>()
            .ForMember(d => d.Roles, o => o.MapFrom(s => s.Roles));

    private void AddMappingProfileFromEntityToModel() =>
        CreateMap<User, UserDataModel>();
}