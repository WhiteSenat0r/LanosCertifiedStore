// using Application.Contracts.RepositoryRelated.Common;
// using Application.Enums.RequestParametersRelated;
// using Domain.Entities.VehicleRelated;
// using Persistence.QueryBuilder.Common;
//
// namespace Persistence.Repositories.VehicleBrandRelated.QueryBuilderRelated.Common.Classes;
//
// internal class VehicleBrandSelectionProfiles : 
//     BaseSelectionProfiles<VehicleBrandProjectionProfile, VehicleBrand, VehicleBrand>
// {
//     private readonly Dictionary<VehicleBrandProjectionProfile,
//             Func<IQueryable<VehicleBrand>, IQueryable<VehicleBrand>>>
//         _mappedProfiles = new()
//         {
//             { VehicleBrandProjectionProfile.Default, GetCatalogProfileQueryable },
//             { VehicleBrandProjectionProfile.Single, GetSingleProfileQueryable },
//         };
//
//     public override IQueryable<VehicleBrand> GetSuitableSelectionProfileQueryable(
//         IQueryable<VehicleBrand> inputQueryable,
//         IFilteringRequestParameters<VehicleBrand>? requestParameters = null)
//     {
//         if (requestParameters is null)
//         {
//             return _mappedProfiles[VehicleBrandProjectionProfile.Default](inputQueryable);
//         }
//
//         var brandRequestParams = requestParameters as IVehicleBrandFilteringRequestParameters;
//
//         return _mappedProfiles[brandRequestParams!.ProjectionProfile](inputQueryable);
//     }
//
//     private static IQueryable<VehicleBrand> GetCatalogProfileQueryable(
//         IQueryable<VehicleBrand> queryable) =>
//         queryable.Select(vehicleBrand => new VehicleBrand
//         {
//             Id = vehicleBrand.Id,
//             Name = vehicleBrand.Name
//         });
//     
//     private static IQueryable<VehicleBrand> GetSingleProfileQueryable(
//         IQueryable<VehicleBrand> queryable) =>
//         queryable.Select(vehicleBrand => new VehicleBrand
//         {
//             Id = vehicleBrand.Id,
//             Name = vehicleBrand.Name,
//             Models = (vehicleBrand.Models.Select(vehicleModel => new VehicleModel
//             {
//                 Id = vehicleModel.Id,
//                 Name = vehicleModel.Name
//             }) as ICollection<VehicleModel>)!
//         });
// }