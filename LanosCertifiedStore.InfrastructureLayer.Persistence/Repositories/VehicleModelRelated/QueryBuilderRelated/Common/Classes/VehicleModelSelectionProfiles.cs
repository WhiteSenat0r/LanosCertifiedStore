using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Persistence.DataModels.VehicleRelated;
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
            VehicleBrand = vehicleModel.VehicleBrand,
            MinimalProductionYear = vehicleModel.MinimalProductionYear,
            MaximumProductionYear = vehicleModel.MaximumProductionYear
        });
    
    private static IQueryable<VehicleModelDataModel> GetSingleProfileQueryable(
        IQueryable<VehicleModelDataModel> queryable) =>
        queryable.Select(vehicleModel => new VehicleModelDataModel
        {
            Id = vehicleModel.Id,
            Name = vehicleModel.Name,
            VehicleBrand = vehicleModel.VehicleBrand,
            VehicleType = vehicleModel.VehicleType,
            AvailableBodyTypes = vehicleModel.AvailableBodyTypes,
            AvailableEngineTypes = vehicleModel.AvailableEngineTypes,
            AvailableTransmissionTypes = vehicleModel.AvailableTransmissionTypes,
            AvailableDrivetrainTypes = vehicleModel.AvailableDrivetrainTypes,
            MinimalProductionYear = vehicleModel.MinimalProductionYear,
            MaximumProductionYear = vehicleModel.MaximumProductionYear
        });
}