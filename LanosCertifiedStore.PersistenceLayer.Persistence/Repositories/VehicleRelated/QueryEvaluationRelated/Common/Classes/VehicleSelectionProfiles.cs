using Domain.Contracts.RepositoryRelated;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation.Common;

namespace Persistence.Repositories.VehicleRelated.QueryEvaluationRelated.Common.Classes;

internal class VehicleSelectionProfiles : 
    BaseSelectionProfiles<VehicleSelectionProfile, Vehicle, VehicleDataModel>
{
    private readonly Dictionary<VehicleSelectionProfile,
            Func<IQueryable<VehicleDataModel>, IVehicleFilteringRequestParameters?, IQueryable<VehicleDataModel>>>
        _mappedProfiles = new()
        {
            { VehicleSelectionProfile.Default, GetDefaultProfileQueryable! },
            { VehicleSelectionProfile.Single, GetSingleProfileQueryable! },
            { VehicleSelectionProfile.Catalog, GetCatalogProfileQueryable! },
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
            Prices = vehicleFilteringRequestParameters.MinimalPriceDate.HasValue
                ? new List<VehiclePriceDataModel>
                {
                    vehicle.Prices!
                        .Where(price => price.IssueDate >= vehicleFilteringRequestParameters.MinimalPriceDate)
                        .Select(price => new VehiclePriceDataModel
                        {
                            IssueDate = price.IssueDate,
                            Value = price.Value
                        })
                        .OrderByDescending(price =>
                            Math.Abs((price.IssueDate - vehicleFilteringRequestParameters.MinimalPriceDate).Value
                                .TotalMilliseconds))
                        .First()
                }
                : new List<VehiclePriceDataModel>
                {
                    vehicle.Prices!.Select(price => new VehiclePriceDataModel
                    {
                        IssueDate = price.IssueDate,
                        Value = price.Value
                    }).OrderByDescending(price => price.IssueDate).First()
                },
            Displacement = vehicle.Displacement,
            Color = new VehicleColorDataModel
            {
                Name = vehicle.Color.Name,
                HexValue = vehicle.Color.HexValue
            },
            Images = new List<VehicleImageDataModel>
            {
                vehicle.Images.Where(image => image.IsMainImage)
                    .Select(image => new VehicleImageDataModel
                    {
                        ImageUrl = image.ImageUrl
                    }).First()
            },
            Type = new VehicleTypeDataModel
            {
                Name = vehicle.Type.Name
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
            Prices = (vehicle.Prices!.Select(price => new VehiclePriceDataModel
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
            Images = (vehicle.Images!.Select(image => new VehicleImageDataModel
            {
                Id = image.Id,
                ImageUrl = image.ImageUrl,
                IsMainImage = image.IsMainImage
            }).OrderByDescending(image => image.IsMainImage) as ICollection<VehicleImageDataModel>)!,
            Type = new VehicleTypeDataModel
            {
                Id = vehicle.Type.Id,
                Name = vehicle.Type.Name
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
                vehicle.Prices!.Select(price => new VehiclePriceDataModel
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
                vehicle.Images.Where(image => image.IsMainImage)
                    .Select(image => new VehicleImageDataModel
                    {
                        ImageUrl = image.ImageUrl
                    }).First()
            },
            Type = new VehicleTypeDataModel
            {
                Name = vehicle.Type.Name
            }
        });
}