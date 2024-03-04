using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.UserRelated;
using Persistence.DataModels.UserRelated;
using Persistence.QueryEvaluation.Common;

namespace Persistence.Repositories.IdentityRelated.QueryBuilderRelated.Common.Classes;

// TODO Implement
// internal sealed class UserFilteringCriteria : BaseFilteringCriteria<User, UserDataModel>
// {
//     internal override Expression<Func<UserDataModel, bool>> GetCriteria(
//         IFilteringRequestParameters<User>? filteringRequestParameters)
//     {
//         var userFilteringCriteria = filteringRequestParameters as IUserFilteringRequestParameters;
//
//         return user =>
//             (string.IsNullOrEmpty(userFilteringCriteria!.FirstName)
//              || user.FirstName.Equals(userFilteringCriteria.FirstName)) &&
//             (string.IsNullOrEmpty(userFilteringCriteria!.LastName)
//              || user.LastName.Equals(userFilteringCriteria.LastName)) &&
//             (string.IsNullOrEmpty(userFilteringCriteria.Email)
//              || user.Email.Equals(userFilteringCriteria.Email));
//     }
// }