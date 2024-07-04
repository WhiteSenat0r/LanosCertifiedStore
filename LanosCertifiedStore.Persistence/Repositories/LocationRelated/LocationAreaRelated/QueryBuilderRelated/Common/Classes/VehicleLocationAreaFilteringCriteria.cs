// using System.Linq.Expressions;
// using Application.Contracts.RepositoryRelated.Common;
// using Domain.Entities.VehicleRelated.LocationRelated;
// using Persistence.QueryBuilder.Common;
//
// namespace Persistence.Repositories.LocationRelated.LocationAreaRelated.QueryBuilderRelated.Common.Classes;
//
// internal sealed class VehicleLocationAreaFilteringCriteria : 
//     BaseFilteringCriteria<VehicleLocationArea, VehicleLocationArea,
//         IVehicleLocationAreaFilteringRequestParameters>
// { 
//     internal override Expression<Func<VehicleLocationArea, bool>> GetCriteria(
//         IFilteringRequestParameters<VehicleLocationArea>? filteringRequestParameters)
//     { 
//         var vehicleTypeFilteringParameters = filteringRequestParameters 
//             as IVehicleLocationAreaFilteringRequestParameters;
//
//         return vehicleType =>
//             string.IsNullOrEmpty(vehicleTypeFilteringParameters!.Name)
//             || vehicleType.Name.Equals(vehicleTypeFilteringParameters.Name);
//     }
//     
//     private protected override void AddPredicateMethodsToList(
//         IVehicleLocationAreaFilteringRequestParameters requestParameters)
//     {
//         if (!string.IsNullOrEmpty(requestParameters.Name))
//         {
//             PredicateDelegates.Add(GetNamePredicate);
//         }
//     }
//
//     private Expression<Func<VehicleLocationArea, bool>> GetNamePredicate(
//         IVehicleLocationAreaFilteringRequestParameters requestParameters) =>
//         vehicleType => vehicleType.Name.Equals(requestParameters.Name);
// }