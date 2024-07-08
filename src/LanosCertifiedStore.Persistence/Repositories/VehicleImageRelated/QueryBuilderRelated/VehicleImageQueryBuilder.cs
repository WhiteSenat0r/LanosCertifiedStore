// using Application.Contracts.RepositoryRelated.Common;
// using Domain.Entities.VehicleRelated;
// using Persistence.QueryBuilder;
// using Persistence.Repositories.VehicleImageRelated.QueryBuilderRelated.Common.Classes;
//
// namespace Persistence.Repositories.VehicleImageRelated.QueryBuilderRelated;
//
// internal sealed class VehicleImageQueryBuilder(
//     VehicleImageSelectionProfiles imageSelectionProfile,
//     VehicleImageFilteringCriteria imageFilteringCriteria)
//     : BaseQueryBuilder<VehicleImageSelectionProfile,
//         VehicleImage,
//         VehicleImage,
//         IVehicleImageFilteringRequestParameters>(
//         imageSelectionProfile,
//         imageFilteringCriteria)
// {
//     private protected override VehicleImageSortingSettings GetQuerySortingSettings(
//         IFilteringRequestParameters<VehicleImage>? filteringRequestParameters) =>
//         new()
//         {
//             OrderByAscendingExpression = VehicleImageSortingTypes.Options["default"]
//         };
// }