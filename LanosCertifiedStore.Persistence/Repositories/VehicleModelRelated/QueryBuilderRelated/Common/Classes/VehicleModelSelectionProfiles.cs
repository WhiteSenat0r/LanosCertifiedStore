using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Domain.Entities.VehicleRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehicleModelRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleModelSelectionProfiles : 
    BaseSelectionProfiles<VehicleModelSelectionProfile, VehicleModel, VehicleModel>
{
    private readonly Dictionary<VehicleModelSelectionProfile,
            Func<IQueryable<VehicleModel>, IQueryable<VehicleModel>>>
        _mappedProfiles = new()
        {
            { VehicleModelSelectionProfile.Default, GetDefaultProfileQueryable },
            { VehicleModelSelectionProfile.Single, GetSingleProfileQueryable },
        };

    public override IQueryable<VehicleModel> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleModel> inputQueryable,
        IFilteringRequestParameters<VehicleModel>? requestParameters = null)
    {
        if (requestParameters is null)
        {
            return _mappedProfiles[VehicleModelSelectionProfile.Default](inputQueryable);
        }

        var brandRequestParams = requestParameters as IVehicleModelFilteringRequestParameters;

        return _mappedProfiles[brandRequestParams!.SelectionProfile](inputQueryable);
    }

    private static IQueryable<VehicleModel> GetDefaultProfileQueryable(
        IQueryable<VehicleModel> queryable) =>
        queryable.Select(vehicleModel => new VehicleModel
        {
            Id = vehicleModel.Id,
            Name = vehicleModel.Name,
            VehicleBrand = vehicleModel.VehicleBrand,
            MinimalProductionYear = vehicleModel.MinimalProductionYear,
            MaximumProductionYear = vehicleModel.MaximumProductionYear
        });
    
    private static IQueryable<VehicleModel> GetSingleProfileQueryable(
        IQueryable<VehicleModel> queryable) =>
        queryable.Select(vehicleModel => new VehicleModel
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