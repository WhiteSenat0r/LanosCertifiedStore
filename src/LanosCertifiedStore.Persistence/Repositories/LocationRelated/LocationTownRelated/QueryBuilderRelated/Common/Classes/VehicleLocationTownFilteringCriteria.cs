// using System.Linq.Expressions;
// using Application.Contracts.RepositoryRelated.Common;
// using Domain.Entities.VehicleRelated.LocationRelated;
// using Persistence.QueryBuilder.Common;
//
// namespace Persistence.Repositories.LocationRelated.LocationTownRelated.QueryBuilderRelated.Common.Classes;
//
// internal sealed class VehicleLocationTownFilteringCriteria : 
//     BaseFilteringCriteria<VehicleLocationTown, VehicleLocationTown,
//         IVehicleLocationTownFilteringRequestParameters>
// { 
//     internal override Expression<Func<VehicleLocationTown, bool>> GetCriteria(
//         IFilteringRequestParameters<VehicleLocationTown>? filteringRequestParameters)
//     { 
//         var vehicleTypeFilteringParameters = filteringRequestParameters 
//             as IVehicleLocationTownFilteringRequestParameters;
//
//         return vehicleType =>
//             string.IsNullOrEmpty(vehicleTypeFilteringParameters!.Name)
//             || vehicleType.Name.Equals(vehicleTypeFilteringParameters.Name);
//     }
//     
//     private protected override void AddPredicateMethodsToList(
//         IVehicleLocationTownFilteringRequestParameters requestParameters)
//     {
//         if (!string.IsNullOrEmpty(requestParameters.Name))
//         {
//             PredicateDelegates.Add(GetNamePredicate);
//         }
//     }
//
//     private Expression<Func<VehicleLocationTown, bool>> GetNamePredicate(
//         IVehicleLocationTownFilteringRequestParameters requestParameters) =>
//         vehicleType => vehicleType.Name.Equals(requestParameters.Name);
// }