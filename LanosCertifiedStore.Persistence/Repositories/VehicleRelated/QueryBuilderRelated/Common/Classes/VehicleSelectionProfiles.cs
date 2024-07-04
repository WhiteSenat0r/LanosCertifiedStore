// using Application.Contracts.RepositoryRelated.Common;
// using Application.Contracts.RequestParametersRelated;
// using Domain.Entities.VehicleRelated;
// using Domain.Entities.VehicleRelated.LocationRelated;
// using Domain.Entities.VehicleRelated.TypeRelated;
// using Persistence.QueryBuilder.Common;
//
// namespace Persistence.Repositories.VehicleRelated.QueryBuilderRelated.Common.Classes;
//
// internal class VehicleSelectionProfiles :
//     BaseSelectionProfiles<VehicleSelectionProfile, Vehicle, Vehicle>
// {
//     private readonly Dictionary<VehicleSelectionProfile,
//             Func<IQueryable<Vehicle>, IVehicleFilteringRequestParameters?, IQueryable<Vehicle>>>
//         _mappedProfiles = new()
//         {
//             { VehicleSelectionProfile.Default, GetDefaultProfileQueryable! },
//             { VehicleSelectionProfile.Catalog, GetCatalogProfileQueryable! },
//             { VehicleSelectionProfile.Single, GetSingleProfileQueryable! }
//         };
//
//     public override IQueryable<Vehicle> GetSuitableSelectionProfileQueryable(
//         IQueryable<Vehicle> inputQueryable,
//         IFilteringRequestParameters<Vehicle>? requestParameters = null)
//     {
//         if (requestParameters is null)
//         {
//             return _mappedProfiles[VehicleSelectionProfile.Default](inputQueryable, null);
//         }
//
//         var requestParams = requestParameters as IVehicleFilteringRequestParameters;
//
//         return _mappedProfiles[requestParams!.SelectionProfile](inputQueryable, requestParams);
//     }
//
//     private static IQueryable<Vehicle> GetCatalogProfileQueryable(
//         IQueryable<Vehicle> queryable,
//         IVehicleFilteringRequestParameters vehicleFilteringRequestParameters) =>
//         queryable.Select(vehicle => new Vehicle
//         {
//             Id = vehicle.Id,
//             Brand = new VehicleBrand
//             {
//                 Name = vehicle.Brand.Name
//             },
//             Model = new VehicleModel
//             {
//                 Name = vehicle.Model.Name
//             },
//             Prices = new List<VehiclePrice>
//             {
//                 vehicle.Prices.Select(price => new VehiclePrice
//                 {
//                     IssueDate = price.IssueDate,
//                     Value = price.Value
//                 }).OrderByDescending(price => price.IssueDate).First()
//             },
//             Displacement = vehicle.Displacement,
//             Mileage = vehicle.Mileage,
//             ProductionYear = vehicle.ProductionYear,
//             Color = new VehicleColor
//             {
//                 Name = vehicle.Color.Name,
//                 HexValue = vehicle.Color.HexValue
//             },
//             Images = new List<VehicleImage>
//             {
//                 vehicle.Images.Count != 0 ? 
//                     vehicle.Images.Where(image => image.IsMainImage)
//                         .Select(image => new VehicleImage
//                         {
//                             ImageUrl = image.ImageUrl
//                         }).First()
//                     : null!
//             },
//             VehicleType = new VehicleType
//             {
//                 Name = vehicle.VehicleType.Name
//             },
//             BodyType = new VehicleBodyType
//             {
//                 Name = vehicle.BodyType.Name
//             },
//             EngineType = new VehicleEngineType
//             {
//                 Name = vehicle.EngineType.Name
//             },
//             LocationTown = new VehicleLocationTown
//             {
//                 Name = vehicle.LocationTown.Name
//             }
//         });
//
//     private static IQueryable<Vehicle> GetSingleProfileQueryable(
//         IQueryable<Vehicle> queryable,
//         IVehicleFilteringRequestParameters vehicleFilteringRequestParameters) =>
//         queryable.Select(vehicle => new Vehicle
//         {
//             Id = vehicle.Id,
//             Brand = new VehicleBrand
//             {
//                 Id = vehicle.Brand.Id,
//                 Name = vehicle.Brand.Name
//             },
//             Model = new VehicleModel
//             {
//                 Id = vehicle.Model.Id,
//                 Name = vehicle.Model.Name
//             },
//             Prices = (vehicle.Prices.Select(price => new VehiclePrice
//             {
//                 Id = price.Id,
//                 Value = price.Value,
//                 IssueDate = price.IssueDate
//             }).OrderByDescending(price => price.IssueDate) as ICollection<VehiclePrice>)!,
//             Displacement = vehicle.Displacement,
//             Description = vehicle.Description,
//             Color = new VehicleColor
//             {
//                 Id = vehicle.Color.Id,
//                 Name = vehicle.Color.Name,
//                 HexValue = vehicle.Color.HexValue
//             },
//             Images = (vehicle.Images.Select(image => new VehicleImage
//             {
//                 Id = image.Id,
//                 ImageUrl = image.ImageUrl,
//                 CloudImageId = image.CloudImageId,
//                 IsMainImage = image.IsMainImage
//             }).OrderByDescending(image => image.IsMainImage) as ICollection<VehicleImage>)!,
//             VehicleType = new VehicleType
//             {
//                 Id = vehicle.VehicleType.Id,
//                 Name = vehicle.VehicleType.Name
//             }
//         });
//
//     private static IQueryable<Vehicle> GetDefaultProfileQueryable(
//         IQueryable<Vehicle> queryable,
//         IVehicleFilteringRequestParameters vehicleFilteringRequestParameters) =>
//         queryable.Select(vehicle => new Vehicle
//         {
//             Id = vehicle.Id,
//             Brand = new VehicleBrand
//             {
//                 Name = vehicle.Brand.Name
//             },
//             Model = new VehicleModel
//             {
//                 Name = vehicle.Model.Name
//             },
//             Prices = new List<VehiclePrice>
//             {
//                 vehicle.Prices.Select(price => new VehiclePrice
//                 {
//                     IssueDate = price.IssueDate,
//                     Value = price.Value
//                 }).OrderByDescending(price => price.IssueDate).First()
//             },
//             Color = new VehicleColor
//             {
//                 Name = vehicle.Color.Name
//             },
//             Images = new List<VehicleImage>
//             {
//                 vehicle.Images.Count != 0 ?
//                 vehicle.Images.Where(image => image.IsMainImage)
//                     .Select(image => new VehicleImage
//                     {
//                         ImageUrl = image.ImageUrl
//                     }).First()
//                 : null!
//             },
//             VehicleType = new VehicleType
//             {
//                 Name = vehicle.VehicleType.Name
//             }
//         });
// }