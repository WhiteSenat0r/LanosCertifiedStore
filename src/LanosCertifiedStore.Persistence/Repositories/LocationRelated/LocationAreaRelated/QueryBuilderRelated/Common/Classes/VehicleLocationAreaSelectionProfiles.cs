// using Application.Contracts.RepositoryRelated.Common;
// using Domain.Entities.VehicleRelated.LocationRelated;
// using Persistence.QueryBuilder.Common;
//
// namespace Persistence.Repositories.LocationRelated.LocationAreaRelated.QueryBuilderRelated.Common.Classes;
//
// internal class VehicleLocationAreaSelectionProfiles : 
//     BaseSelectionProfiles<VehicleLocationAreaSelectionProfile, VehicleLocationArea, VehicleLocationArea>
// {
//     private readonly Dictionary<VehicleColorSelectionProfile,
//             Func<IQueryable<VehicleLocationArea>, IQueryable<VehicleLocationArea>>>
//         _mappedProfiles = new()
//         {
//             { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
//         };
//
//     public override IQueryable<VehicleLocationArea> GetSuitableSelectionProfileQueryable(
//         IQueryable<VehicleLocationArea> inputQueryable,
//         IFilteringRequestParameters<VehicleLocationArea>? requestParameters = null) =>
//         _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);
//
//     private static IQueryable<VehicleLocationArea> GetDefaultProfileQueryable(
//         IQueryable<VehicleLocationArea> queryable) =>
//         queryable.Select(vehicleType => new VehicleLocationArea
//         {
//             Id = vehicleType.Id,
//             Name = vehicleType.Name,
//         });
// }