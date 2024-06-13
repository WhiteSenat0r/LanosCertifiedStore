using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Domain.Models.VehicleRelated.Classes;
using Persistence.DataModels.VehicleRelated;
using Persistence.DataModels.VehicleRelated.LocationRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehicleRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleSelectionProfiles :
    BaseSelectionProfiles<VehicleSelectionProfile, Vehicle, VehicleDataModel>
{
    private readonly Dictionary<VehicleSelectionProfile,
            Func<IQueryable<VehicleDataModel>, IVehicleFilteringRequestParameters?, IQueryable<VehicleDataModel>>>
        _mappedProfiles = new()
        {
            { VehicleSelectionProfile.Default, GetDefaultProfileQueryable! },
            { VehicleSelectionProfile.Catalog, GetCatalogProfileQueryable! },
            { VehicleSelectionProfile.Single, GetSingleProfileQueryable! }
        };

    public override IQueryable<VehicleDataModel> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleDataModel> inputQueryable,
        IFilteringRequestParameters<Vehicle>? requestParameters = null)
    {
        if (requestParameters is null)
            return _mappedProfiles[VehicleSelectionProfile.Default](inputQueryable, null);

        var requestParams = requestParameters as IVehicleFilteringRequestParameters;

        return _mappedProfiles[requestParams!.SelectionProfile](inputQueryable, requestParams);
    }

    private static IQueryable<VehicleDataModel> GetCatalogProfileQueryable(
        IQueryable<VehicleDataModel> queryable,
        IVehicleFilteringRequestParameters vehicleFilteringRequestParameters) =>
        queryable.Select(vehicle => new VehicleDataModel
        {
            Id = vehicle.Id,
            Brand = new VehicleBrandDataModel
            {
                Name = vehicle.Brand.Name
            },
            Model = new VehicleModelDataModel
            {
                Name = vehicle.Model.Name
            },
            Prices = new List<VehiclePriceDataModel>
            {
                vehicle.Prices.Select(price => new VehiclePriceDataModel
                {
                    IssueDate = price.IssueDate,
                    Value = price.Value
                }).OrderByDescending(price => price.IssueDate).First()
            },
            Displacement = vehicle.Displacement,
            Mileage = vehicle.Mileage,
            ProductionYear = vehicle.ProductionYear,
            Color = new VehicleColorDataModel
            {
                Name = vehicle.Color.Name,
                HexValue = vehicle.Color.HexValue
            },
            Images = new List<VehicleImageDataModel>
            {
                vehicle.Images.Count != 0 ? 
                    vehicle.Images.Where(image => image.IsMainImage)
                        .Select(image => new VehicleImageDataModel
                        {
                            ImageUrl = image.ImageUrl
                        }).First()
                    : null!
            },
            VehicleType = new VehicleTypeDataModel
            {
                Name = vehicle.VehicleType.Name
            },
            BodyType = new VehicleBodyTypeDataModel
            {
                Name = vehicle.BodyType.Name
            },
            EngineType = new VehicleEngineTypeDataModel
            {
                Name = vehicle.EngineType.Name
            },
            LocationTown = new VehicleLocationTownDataModel
            {
                Name = vehicle.LocationTown.Name
            }
        });

    private static IQueryable<VehicleDataModel> GetSingleProfileQueryable(
        IQueryable<VehicleDataModel> queryable,
        IVehicleFilteringRequestParameters vehicleFilteringRequestParameters) =>
        queryable.Select(vehicle => new VehicleDataModel
        {
            Id = vehicle.Id,
            Brand = new VehicleBrandDataModel
            {
                Id = vehicle.Brand.Id,
                Name = vehicle.Brand.Name
            },
            Model = new VehicleModelDataModel
            {
                Id = vehicle.Model.Id,
                Name = vehicle.Model.Name
            },
            Prices = (vehicle.Prices.Select(price => new VehiclePriceDataModel
            {
                Id = price.Id,
                Value = price.Value,
                IssueDate = price.IssueDate
            }).OrderByDescending(price => price.IssueDate) as ICollection<VehiclePriceDataModel>)!,
            Displacement = vehicle.Displacement,
            Description = vehicle.Description,
            Color = new VehicleColorDataModel
            {
                Id = vehicle.Color.Id,
                Name = vehicle.Color.Name,
                HexValue = vehicle.Color.HexValue
            },
            Images = (vehicle.Images.Select(image => new VehicleImageDataModel
            {
                Id = image.Id,
                ImageUrl = image.ImageUrl,
                CloudImageId = image.CloudImageId,
                IsMainImage = image.IsMainImage
            }).OrderByDescending(image => image.IsMainImage) as ICollection<VehicleImageDataModel>)!,
            VehicleType = new VehicleTypeDataModel
            {
                Id = vehicle.VehicleType.Id,
                Name = vehicle.VehicleType.Name
            }
        });

    private static IQueryable<VehicleDataModel> GetDefaultProfileQueryable(
        IQueryable<VehicleDataModel> queryable,
        IVehicleFilteringRequestParameters vehicleFilteringRequestParameters) =>
        queryable.Select(vehicle => new VehicleDataModel
        {
            Id = vehicle.Id,
            Brand = new VehicleBrandDataModel
            {
                Name = vehicle.Brand.Name
            },
            Model = new VehicleModelDataModel
            {
                Name = vehicle.Model.Name
            },
            Prices = new List<VehiclePriceDataModel>
            {
                vehicle.Prices.Select(price => new VehiclePriceDataModel
                {
                    IssueDate = price.IssueDate,
                    Value = price.Value
                }).OrderByDescending(price => price.IssueDate).First()
            },
            Color = new VehicleColorDataModel
            {
                Name = vehicle.Color.Name
            },
            Images = new List<VehicleImageDataModel>
            {
                vehicle.Images.Count != 0 ?
                vehicle.Images.Where(image => image.IsMainImage)
                    .Select(image => new VehicleImageDataModel
                    {
                        ImageUrl = image.ImageUrl
                    }).First()
                : null!
            },
            VehicleType = new VehicleTypeDataModel
            {
                Name = vehicle.VehicleType.Name
            }
        });
}