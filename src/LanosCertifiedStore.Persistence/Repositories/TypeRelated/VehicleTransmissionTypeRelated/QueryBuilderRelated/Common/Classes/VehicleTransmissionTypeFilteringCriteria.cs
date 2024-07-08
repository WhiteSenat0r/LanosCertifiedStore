// using System.Linq.Expressions;
// using Application.Contracts.RepositoryRelated.Common;
// using Domain.Entities.VehicleRelated.TypeRelated;
// using Persistence.QueryBuilder.Common;
//
// namespace Persistence.Repositories.TypeRelated.VehicleTransmissionTypeRelated.QueryBuilderRelated.Common.Classes;
//
// internal sealed class VehicleTransmissionTypeFilteringCriteria : 
//     BaseFilteringCriteria<VehicleTransmissionType,
//         VehicleTransmissionType,
//         IVehicleTransmissionTypeFilteringRequestParameters>
// { 
//     internal override Expression<Func<VehicleTransmissionType, bool>> GetCriteria(
//         IFilteringRequestParameters<VehicleTransmissionType>? filteringRequestParameters)
//     { 
//         var vehicleTransmissionTypeFilteringParameters = filteringRequestParameters as
//             IVehicleTransmissionTypeFilteringRequestParameters;
//
//         return vehicleTransmissionType =>
//             string.IsNullOrEmpty(vehicleTransmissionTypeFilteringParameters!.Name)
//             || vehicleTransmissionType.Name.Equals(vehicleTransmissionTypeFilteringParameters.Name);
//     }
//     
//     private protected override void AddPredicateMethodsToList(
//         IVehicleTransmissionTypeFilteringRequestParameters requestParameters)
//     {
//         if (!string.IsNullOrEmpty(requestParameters.Name))
//         {
//             PredicateDelegates.Add(GetNamePredicate);
//         }
//     }
//
//     private Expression<Func<VehicleTransmissionType, bool>> GetNamePredicate(
//         IVehicleTransmissionTypeFilteringRequestParameters requestParameters) =>
//         vehicleTransmissionType => vehicleTransmissionType.Name.Equals(requestParameters.Name);
// }