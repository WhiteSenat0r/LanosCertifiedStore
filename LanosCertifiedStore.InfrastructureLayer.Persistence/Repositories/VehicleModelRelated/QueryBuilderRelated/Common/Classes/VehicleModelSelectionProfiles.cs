using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Domain.Models.VehicleRelated.Classes;
using Persistence.Entities.VehicleRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehicleModelRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleModelSelectionProfiles : 
    BaseSelectionProfiles<VehicleModelSelectionProfile, VehicleModel, VehicleModelEntity>
{
    private readonly Dictionary<VehicleModelSelectionProfile,
            Func<IQueryable<VehicleModelEntity>, IQueryable<VehicleModelEntity>>>
        _mappedProfiles = new()
        {
            { VehicleModelSelectionProfile.Default, GetDefaultProfileQueryable },
            { VehicleModelSelectionProfile.Single, GetSingleProfileQueryable },
        };

    public override IQueryable<VehicleModelEntity> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleModelEntity> inputQueryable,
        IFilteringRequestParameters<VehicleModel>? requestParameters = null)
    {
        if (requestParameters is null) 
            return _mappedProfiles[VehicleModelSelectionProfile.Default](inputQueryable);
        
        var brandRequestParams = requestParameters as IVehicleModelFilteringRequestParameters;

        return _mappedProfiles[brandRequestParams!.SelectionProfile](inputQueryable);
    }

    private static IQueryable<VehicleModelEntity> GetDefaultProfileQueryable(
        IQueryable<VehicleModelEntity> queryable) =>
        queryable.Select(vehicleModel => new VehicleModelEntity
        {
            Id = vehicleModel.Id,
            Name = vehicleModel.Name,
            VehicleBrand = vehicleModel.VehicleBrand,
            MinimalProductionYear = vehicleModel.MinimalProductionYear,
            MaximumProductionYear = vehicleModel.MaximumProductionYear
        });
    
    private static IQueryable<VehicleModelEntity> GetSingleProfileQueryable(
        IQueryable<VehicleModelEntity> queryable) =>
        queryable.Select(vehicleModel => new VehicleModelEntity
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