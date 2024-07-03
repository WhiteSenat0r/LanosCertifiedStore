﻿// using System.Linq.Expressions;
// using Application.Contracts.RepositoryRelated.Common;
// using Domain.Entities.VehicleRelated.TypeRelated;
// using Persistence.QueryBuilder.Common;
//
// namespace Persistence.Repositories.TypeRelated.VehicleTypeRelated.QueryBuilderRelated.Common.Classes;
//
// internal sealed class VehicleTypeFilteringCriteria : 
//     BaseFilteringCriteria<VehicleType, VehicleType, IVehicleTypeFilteringRequestParameters>
// { 
//     internal override Expression<Func<VehicleType, bool>> GetCriteria(
//         IFilteringRequestParameters<VehicleType>? filteringRequestParameters)
//     { 
//         var vehicleTypeFilteringParameters = filteringRequestParameters as IVehicleTypeFilteringRequestParameters;
//
//         return vehicleType =>
//             string.IsNullOrEmpty(vehicleTypeFilteringParameters!.Name)
//             || vehicleType.Name.Equals(vehicleTypeFilteringParameters.Name);
//     }
//     
//     private protected override void AddPredicateMethodsToList(
//         IVehicleTypeFilteringRequestParameters requestParameters)
//     {
//         if (!string.IsNullOrEmpty(requestParameters.Name))
//         {
//             PredicateDelegates.Add(GetNamePredicate);
//         }
//     }
//
//     private Expression<Func<VehicleType, bool>> GetNamePredicate(
//         IVehicleTypeFilteringRequestParameters requestParameters) =>
//         vehicleType => vehicleType.Name.Equals(requestParameters.Name);
// }