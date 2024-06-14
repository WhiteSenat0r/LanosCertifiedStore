using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Domain.Models.VehicleRelated.Classes;
using Persistence.Entities.VehicleRelated;
using Persistence.Entities.VehicleRelated.LocationRelated;
using Persistence.Entities.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehicleRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleSelectionProfiles :
    BaseSelectionProfiles<VehicleSelectionProfile, Vehicle, VehicleEntity>
{
    private readonly Dictionary<VehicleSelectionProfile,
            Func<IQueryable<VehicleEntity>, IVehicleFilteringRequestParameters?, IQueryable<VehicleEntity>>>
        _mappedProfiles = new()
        {
            { VehicleSelectionProfile.Default, GetDefaultProfileQueryable! },
            { VehicleSelectionProfile.Catalog, GetCatalogProfileQueryable! },
            { VehicleSelectionProfile.Single, GetSingleProfileQueryable! }
        };

    public override IQueryable<VehicleEntity> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleEntity> inputQueryable,
        IFilteringRequestParameters<Vehicle>? requestParameters = null)
    {
        if (requestParameters is null)
            return _mappedProfiles[VehicleSelectionProfile.Default](inputQueryable, null);

        var requestParams = requestParameters as IVehicleFilteringRequestParameters;

        return _mappedProfiles[requestParams!.SelectionProfile](inputQueryable, requestParams);
    }

    private static IQueryable<VehicleEntity> GetCatalogProfileQueryable(
        IQueryable<VehicleEntity> queryable,
        IVehicleFilteringRequestParameters vehicleFilteringRequestParameters) =>
        queryable.Select(vehicle => new VehicleEntity
        {
            Id = vehicle.Id,
            Brand = new VehicleBrandEntity
            {
                Name = vehicle.Brand.Name
            },
            Model = new VehicleModelEntity
            {
                Name = vehicle.Model.Name
            },
            Prices = new List<VehiclePriceEntity>
            {
                vehicle.Prices.Select(price => new VehiclePriceEntity
                {
                    IssueDate = price.IssueDate,
                    Value = price.Value
                }).OrderByDescending(price => price.IssueDate).First()
            },
            Displacement = vehicle.Displacement,
            Mileage = vehicle.Mileage,
            ProductionYear = vehicle.ProductionYear,
            Color = new VehicleColorEntity
            {
                Name = vehicle.Color.Name,
                HexValue = vehicle.Color.HexValue
            },
            Images = new List<VehicleImageEntity>
            {
                vehicle.Images.Count != 0 ? 
                    vehicle.Images.Where(image => image.IsMainImage)
                        .Select(image => new VehicleImageEntity
                        {
                            ImageUrl = image.ImageUrl
                        }).First()
                    : null!
            },
            VehicleType = new VehicleTypeEntity
            {
                Name = vehicle.VehicleType.Name
            },
            BodyType = new VehicleBodyTypeEntity
            {
                Name = vehicle.BodyType.Name
            },
            EngineType = new VehicleEngineTypeEntity
            {
                Name = vehicle.EngineType.Name
            },
            LocationTown = new VehicleLocationTownEntity
            {
                Name = vehicle.LocationTown.Name
            }
        });

    private static IQueryable<VehicleEntity> GetSingleProfileQueryable(
        IQueryable<VehicleEntity> queryable,
        IVehicleFilteringRequestParameters vehicleFilteringRequestParameters) =>
        queryable.Select(vehicle => new VehicleEntity
        {
            Id = vehicle.Id,
            Brand = new VehicleBrandEntity
            {
                Id = vehicle.Brand.Id,
                Name = vehicle.Brand.Name
            },
            Model = new VehicleModelEntity
            {
                Id = vehicle.Model.Id,
                Name = vehicle.Model.Name
            },
            Prices = (vehicle.Prices.Select(price => new VehiclePriceEntity
            {
                Id = price.Id,
                Value = price.Value,
                IssueDate = price.IssueDate
            }).OrderByDescending(price => price.IssueDate) as ICollection<VehiclePriceEntity>)!,
            Displacement = vehicle.Displacement,
            Description = vehicle.Description,
            Color = new VehicleColorEntity
            {
                Id = vehicle.Color.Id,
                Name = vehicle.Color.Name,
                HexValue = vehicle.Color.HexValue
            },
            Images = (vehicle.Images.Select(image => new VehicleImageEntity
            {
                Id = image.Id,
                ImageUrl = image.ImageUrl,
                CloudImageId = image.CloudImageId,
                IsMainImage = image.IsMainImage
            }).OrderByDescending(image => image.IsMainImage) as ICollection<VehicleImageEntity>)!,
            VehicleType = new VehicleTypeEntity
            {
                Id = vehicle.VehicleType.Id,
                Name = vehicle.VehicleType.Name
            }
        });

    private static IQueryable<VehicleEntity> GetDefaultProfileQueryable(
        IQueryable<VehicleEntity> queryable,
        IVehicleFilteringRequestParameters vehicleFilteringRequestParameters) =>
        queryable.Select(vehicle => new VehicleEntity
        {
            Id = vehicle.Id,
            Brand = new VehicleBrandEntity
            {
                Name = vehicle.Brand.Name
            },
            Model = new VehicleModelEntity
            {
                Name = vehicle.Model.Name
            },
            Prices = new List<VehiclePriceEntity>
            {
                vehicle.Prices.Select(price => new VehiclePriceEntity
                {
                    IssueDate = price.IssueDate,
                    Value = price.Value
                }).OrderByDescending(price => price.IssueDate).First()
            },
            Color = new VehicleColorEntity
            {
                Name = vehicle.Color.Name
            },
            Images = new List<VehicleImageEntity>
            {
                vehicle.Images.Count != 0 ?
                vehicle.Images.Where(image => image.IsMainImage)
                    .Select(image => new VehicleImageEntity
                    {
                        ImageUrl = image.ImageUrl
                    }).First()
                : null!
            },
            VehicleType = new VehicleTypeEntity
            {
                Name = vehicle.VehicleType.Name
            }
        });
}