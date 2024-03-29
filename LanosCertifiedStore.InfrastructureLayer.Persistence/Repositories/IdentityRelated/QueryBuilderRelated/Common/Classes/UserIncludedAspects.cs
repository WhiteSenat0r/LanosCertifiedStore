﻿using System.Linq.Expressions;
using Persistence.DataModels.UserRelated;

namespace Persistence.Repositories.IdentityRelated.QueryBuilderRelated.Common.Classes;

internal class UserIncludedAspects
{
    public static readonly List<Expression<Func<UserDataModel, object>>> IncludedAspects =
    [
        user => user.Roles
    ];
}