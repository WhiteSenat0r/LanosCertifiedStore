// using Application.Contracts.RepositoryRelated.Common;
// using Domain.Entities.VehicleRelated.LocationRelated;
// using Persistence.QueryBuilder.Common;
//
// namespace Persistence.Repositories.LocationRelated.LocationTownRelated.QueryBuilderRelated.Common.Classes;
//
// internal class VehicleLocationTownSelectionProfiles : 
//     BaseSelectionProfiles<VehicleLocationTownSelectionProfile, VehicleLocationTown, VehicleLocationTown>
// {
//     private readonly Dictionary<VehicleColorSelectionProfile,
//             Func<IQueryable<VehicleLocationTown>, IQueryable<VehicleLocationTown>>>
//         _mappedProfiles = new()
//         {
//             { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
//         };
//
//     public override IQueryable<VehicleLocationTown> GetSuitableSelectionProfileQueryable(
//         IQueryable<VehicleLocationTown> inputQueryable,
//         IFilteringRequestParameters<VehicleLocationTown>? requestParameters = null) =>
//         _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);
//
//     private static IQueryable<VehicleLocationTown> GetDefaultProfileQueryable(
//         IQueryable<VehicleLocationTown> queryable) =>
//         queryable.Select(vehicleType => new VehicleLocationTown
//         {
//             Id = vehicleType.Id,
//             Name = vehicleType.Name,
//         });
// }