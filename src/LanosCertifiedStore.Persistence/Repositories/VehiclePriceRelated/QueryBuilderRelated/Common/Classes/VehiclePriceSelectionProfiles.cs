// using Application.Contracts.RepositoryRelated.Common;
// using Domain.Entities.VehicleRelated;
// using Persistence.QueryBuilder.Common;
//
// namespace Persistence.Repositories.VehiclePriceRelated.QueryBuilderRelated.Common.Classes;
//
// internal class VehiclePriceSelectionProfiles : 
//     BaseSelectionProfiles<VehiclePriceSelectionProfile, VehiclePrice, VehiclePrice>
// {
//     private readonly Dictionary<VehiclePriceSelectionProfile,
//             Func<IQueryable<VehiclePrice>, IQueryable<VehiclePrice>>>
//         _mappedProfiles = new()
//         {
//             { VehiclePriceSelectionProfile.Default, GetDefaultProfileQueryable },
//             { VehiclePriceSelectionProfile.Full, GetFullProfileQueryable },
//         };
//
//     public override IQueryable<VehiclePrice> GetSuitableSelectionProfileQueryable(
//         IQueryable<VehiclePrice> inputQueryable,
//         IFilteringRequestParameters<VehiclePrice>? requestParameters = null)
//     {
//         if (requestParameters is null)
//         {
//             return _mappedProfiles[VehiclePriceSelectionProfile.Default](inputQueryable);
//         }
//
//         var brandRequestParams = requestParameters as IVehiclePriceFilteringRequestParameters;
//
//         return _mappedProfiles[brandRequestParams!.SelectionProfile](inputQueryable);
//     }
//
//     private static IQueryable<VehiclePrice> GetDefaultProfileQueryable(
//         IQueryable<VehiclePrice> queryable) =>
//         queryable.Select(vehiclePrice => new VehiclePrice
//         {
//             Id = vehiclePrice.Id,
//             Value = vehiclePrice.Value
//         });
//     
//     private static IQueryable<VehiclePrice> GetFullProfileQueryable(
//         IQueryable<VehiclePrice> queryable) =>
//         queryable.Select(vehiclePrice => new VehiclePrice
//         {
//             Id = vehiclePrice.Id,
//             Value = vehiclePrice.Value,
//             IssueDate = vehiclePrice.IssueDate
//         });
// }