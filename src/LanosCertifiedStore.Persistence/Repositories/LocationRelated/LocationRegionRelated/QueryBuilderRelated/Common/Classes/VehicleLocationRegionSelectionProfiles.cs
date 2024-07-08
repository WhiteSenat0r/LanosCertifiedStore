// using Application.Contracts.RepositoryRelated.Common;
// using Domain.Entities.VehicleRelated.LocationRelated;
// using Persistence.QueryBuilder.Common;
//
// namespace Persistence.Repositories.LocationRelated.LocationRegionRelated.QueryBuilderRelated.Common.Classes;
//
// internal class VehicleLocationRegionSelectionProfiles : 
//     BaseSelectionProfiles<VehicleLocationRegionSelectionProfile, VehicleLocationRegion, VehicleLocationRegion>
// {
//     private readonly Dictionary<VehicleColorSelectionProfile,
//             Func<IQueryable<VehicleLocationRegion>, IQueryable<VehicleLocationRegion>>>
//         _mappedProfiles = new()
//         {
//             { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
//         };
//
//     public override IQueryable<VehicleLocationRegion> GetSuitableSelectionProfileQueryable(
//         IQueryable<VehicleLocationRegion> inputQueryable,
//         IFilteringRequestParameters<VehicleLocationRegion>? requestParameters = null) =>
//         _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);
//
//     private static IQueryable<VehicleLocationRegion> GetDefaultProfileQueryable(
//         IQueryable<VehicleLocationRegion> queryable) =>
//         queryable.Select(vehicleType => new VehicleLocationRegion
//         {
//             Id = vehicleType.Id,
//             Name = vehicleType.Name,
//         });
// }