using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels;
using Persistence.QueryEvaluation.Common;

namespace Persistence.Repositories.IdentityRelated.QueryEvaluationRelated.Common.Classes;

internal sealed class UserFilteringCriteria : BaseFilteringCriteria<User, UserDataModel>
{
    internal override Expression<Func<UserDataModel, bool>> GetCriteria(
        IFilteringRequestParameters<User>? filteringRequestParameters)
    {
        var userFilteringCriteria = filteringRequestParameters as IUserFilteringRequestParameters;

        return user =>
            (string.IsNullOrEmpty(userFilteringCriteria!.FirstName)
             || user.FirstName.Equals(userFilteringCriteria.FirstName)) &&
            (string.IsNullOrEmpty(userFilteringCriteria!.LastName)
             || user.LastName.Equals(userFilteringCriteria.LastName)) &&
            (string.IsNullOrEmpty(userFilteringCriteria.Email)
             || user.Email.Equals(userFilteringCriteria.Email));
    }
}