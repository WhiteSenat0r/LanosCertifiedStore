// using System.Linq.Expressions;
// using Application.Contracts.RepositoryRelated.Common;
// using Application.Contracts.RequestParametersRelated;
// using Domain.Entities.VehicleRelated;
// using Persistence.QueryBuilder.Common;
//
// namespace Persistence.Repositories.VehicleModelRelated.QueryBuilderRelated.Common.Classes;
//
// internal sealed class VehicleModelFilteringCriteria 
//     : BaseFilteringCriteria<VehicleModel, VehicleModel, IVehicleModelFilteringRequestParameters>
// { 
//     internal override Expression<Func<VehicleModel, bool>> GetCriteria(
//         IFilteringRequestParameters<VehicleModel>? filteringRequestParameters)
//     {
//         if (filteringRequestParameters is not IVehicleModelFilteringRequestParameters requestParameters)
//         {
//             return GetPredicate();
//         }
//
//         AddPredicateMethodsToList(requestParameters);
//         
//         return GetPredicate(requestParameters);
//     }
//
//     private protected override void AddPredicateMethodsToList(
//         IVehicleModelFilteringRequestParameters requestParameters)
//     {
//         if (!string.IsNullOrEmpty(requestParameters.Name))
//         {
//             PredicateDelegates.Add(GetModelNamePredicate);
//         }
//
//         if (!string.IsNullOrEmpty(requestParameters.ContainedBrandName))
//         {
//             PredicateDelegates.Add(GetContainedBrandNamePredicate);
//         }
//     }
//     
//     private Expression<Func<VehicleModel, bool>> GetContainedBrandNamePredicate(
//         IVehicleModelFilteringRequestParameters requestParameters) =>
//         vehicleModel => vehicleModel.VehicleBrand.Name.Equals(
//             requestParameters.ContainedBrandName);
//
//     private Expression<Func<VehicleModel, bool>> GetModelNamePredicate(
//         IVehicleModelFilteringRequestParameters requestParameters) =>
//         vehicleModel => vehicleModel.Name.Equals(requestParameters.Name);
// }