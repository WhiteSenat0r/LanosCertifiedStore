namespace Persistence.Repositories.IdentityRelated.QueryEvaluationRelated;

// TODO Add implementation
// internal sealed class UserQueryEvaluator(
//     IEnumerable<Expression<Func<UserDataModel, object>>> selectionProfiles,
//     IFilteringRequestParameters<User>? filteringRequestParameters,
//     DbSet<UserDataModel> dataModels,
//     UserFilteringCriteria userFilteringCriteria)
//     : BaseQueryEvaluator<User, UserDataModel>(
//         selectionProfiles,
//         filteringRequestParameters,
//         dataModels,
//         userFilteringCriteria)
// {
//     private protected override BaseSortingSettings<UserDataModel> GetQuerySortingSettings()
//     {
//         if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
//             return new UserSortingSettings
//             {
//                 OrderByAscendingExpression = UserSortingTypes.Options["default"]
//             };
//
//         var settings = new UserSortingSettings();
//
//         if (filteringRequestParameters.SortingType.Contains("-asc"))
//             settings.OrderByAscendingExpression = UserSortingTypes.Options
//                 [filteringRequestParameters.SortingType];
//         else if (filteringRequestParameters.SortingType.Contains("-desc"))
//             settings.OrderByDescendingExpression = UserSortingTypes.Options
//                 [filteringRequestParameters.SortingType];
//
//         return settings;
//     }
// }