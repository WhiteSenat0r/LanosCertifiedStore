using System.Linq.Expressions;
using Persistence.Entities.UserRelated;

namespace Persistence.Repositories.IdentityRelated.QueryBuilderRelated.Common.Classes;

internal class UserIncludedAspects
{
    public static readonly List<Expression<Func<UserEntity, object>>> IncludedAspects =
    [
        user => user.Roles
    ];
}