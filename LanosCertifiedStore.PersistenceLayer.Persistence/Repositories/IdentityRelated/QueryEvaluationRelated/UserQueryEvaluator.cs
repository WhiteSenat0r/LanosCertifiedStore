using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.UserRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels.UserRelated;
using Persistence.QueryEvaluation;
using Persistence.QueryEvaluation.Common;
using Persistence.Repositories.IdentityRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.IdentityRelated.QueryEvaluationRelated;

internal sealed class UserQueryEvaluator(
    IEnumerable<Expression<Func<UserDataModel, object>>> includedAspects,
    IFilteringRequestParameters<User>? filteringRequestParameters,
    DbSet<UserDataModel> dataModels,
    UserFilteringCriteria userFilteringCriteria)
    : BaseQueryEvaluator<User, UserDataModel>(
        includedAspects,
        filteringRequestParameters,
        dataModels,
        userFilteringCriteria)
{
    private protected override BaseSortingSettings<UserDataModel> GetQuerySortingSettings()
    {
        if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
            return new UserSortingSettings
            {
                OrderByAscendingExpression = UserSortingTypes.Options["default"]
            };

        var settings = new UserSortingSettings();

        if (filteringRequestParameters.SortingType.Contains("-asc"))
            settings.OrderByAscendingExpression = UserSortingTypes.Options
                [filteringRequestParameters.SortingType];
        else if (filteringRequestParameters.SortingType.Contains("-desc"))
            settings.OrderByDescendingExpression = UserSortingTypes.Options
                [filteringRequestParameters.SortingType];

        return settings;
    }
}