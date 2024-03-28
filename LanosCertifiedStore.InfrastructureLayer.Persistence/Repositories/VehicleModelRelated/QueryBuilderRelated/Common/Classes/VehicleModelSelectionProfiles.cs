using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Persistence.DataModels.VehicleRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehicleModelRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleModelSelectionProfiles : 
    BaseSelectionProfiles<VehicleModelSelectionProfile, VehicleModel, VehicleModelDataModel>
{
    private readonly Dictionary<VehicleModelSelectionProfile,
            Func<IQueryable<VehicleModelDataModel>, IQueryable<VehicleModelDataModel>>>
        _mappedProfiles = new()
        {
            { VehicleModelSelectionProfile.Default, GetDefaultProfileQueryable },
            { VehicleModelSelectionProfile.Single, GetSingleProfileQueryable },
        };

    public override IQueryable<VehicleModelDataModel> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleModelDataModel> inputQueryable,
        IFilteringRequestParameters<VehicleModel>? requestParameters = null)
    {
        if (requestParameters is null) 
            return _mappedProfiles[VehicleModelSelectionProfile.Default](inputQueryable);
        
        var brandRequestParams = requestParameters as IVehicleModelFilteringRequestParameters;

        return _mappedProfiles[brandRequestParams!.SelectionProfile](inputQueryable);
    }

    private static IQueryable<VehicleModelDataModel> GetDefaultProfileQueryable(
        IQueryable<VehicleModelDataModel> queryable) =>
        queryable.Select(vehicleModel => new VehicleModelDataModel
        {
            Id = vehicleModel.Id,
            Name = vehicleModel.Name,
            VehicleBrand = new VehicleBrandDataModel
            {
                Id = vehicleModel.VehicleBrand.Id,
                Name = vehicleModel.VehicleBrand.Name
            },
            VehicleType = new VehicleTypeDataModel
            {
                Id = vehicleModel.VehicleType.Id,
                Name = vehicleModel.VehicleType.Name
            },
            MinimalProductionYear = vehicleModel.MinimalProductionYear,
            MaximumProductionYear = vehicleModel.MaximumProductionYear
        });
    
    // TODO
    private static IQueryable<VehicleModelDataModel> GetSingleProfileQueryable(
        IQueryable<VehicleModelDataModel> queryable) =>
        queryable.Select(vehicleModel => new VehicleModelDataModel
        {
            Id = vehicleModel.Id,
            Name = vehicleModel.Name,
            VehicleBrand = new VehicleBrandDataModel
            {
                Id = vehicleModel.VehicleBrand.Id,
                Name = vehicleModel.VehicleBrand.Name
            },
            VehicleType = new VehicleTypeDataModel
            {
                Id = vehicleModel.VehicleType.Id,
                Name = vehicleModel.VehicleType.Name
            },
            AvailableBodyTypes = (vehicleModel.AvailableBodyTypes.Select(
                b => new VehicleBodyTypeDataModel
                {
                    Name = b.Name
                })
                as ICollection<VehicleBodyTypeDataModel>)!,
            AvailableEngineTypes = (vehicleModel.AvailableEngineTypes.Select(
                    e => new VehicleEngineTypeDataModel
                    {
                        Name = e.Name
                    })
                as ICollection<VehicleEngineTypeDataModel>)!,
            AvailableTransmissionTypes = (vehicleModel.AvailableTransmissionTypes.Select(
                    e => new VehicleTransmissionTypeDataModel
                    {
                        Name = e.Name
                    })
                as ICollection<VehicleTransmissionTypeDataModel>)!,
            AvailableDrivetrainTypes = (vehicleModel.AvailableDrivetrainTypes.Select(
                    e => new VehicleDrivetrainTypeDataModel
                    {
                        Name = e.Name
                    })
                as ICollection<VehicleDrivetrainTypeDataModel>)!,
            MinimalProductionYear = vehicleModel.MinimalProductionYear,
            MaximumProductionYear = vehicleModel.MaximumProductionYear
        });
}