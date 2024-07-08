// using Application.Contracts.RepositoryRelated.Common;
// using Domain.Entities.VehicleRelated.TypeRelated;
// using Persistence.QueryBuilder.Common;
//
// namespace Persistence.Repositories.TypeRelated.VehicleTransmissionTypeRelated.QueryBuilderRelated.Common.Classes;
//
// internal class VehicleTransmissionTypeSelectionProfiles : 
//     BaseSelectionProfiles<VehicleTransmissionTypeSelectionProfile,
//         VehicleTransmissionType,
//         VehicleTransmissionType>
// {
//     private readonly Dictionary<VehicleColorSelectionProfile,
//             Func<IQueryable<VehicleTransmissionType>, IQueryable<VehicleTransmissionType>>>
//         _mappedProfiles = new()
//         {
//             { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
//         };
//
//     public override IQueryable<VehicleTransmissionType> GetSuitableSelectionProfileQueryable(
//         IQueryable<VehicleTransmissionType> inputQueryable,
//         IFilteringRequestParameters<VehicleTransmissionType>? requestParameters = null) =>
//         _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);
//
//     private static IQueryable<VehicleTransmissionType> GetDefaultProfileQueryable(
//         IQueryable<VehicleTransmissionType> queryable) =>
//         queryable.Select(vehicleTransmissionType => new VehicleTransmissionType
//         {
//             Id = vehicleTransmissionType.Id,
//             Name = vehicleTransmissionType.Name,
//         });
// }