using Domain.Contracts.RepositoryRelated;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation.Common;

namespace Persistence.Repositories.VehicleModelRelated.QueryEvaluationRelated.Common.Classes;

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
        });
    
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
            AvailableTypes = (vehicleModel.AvailableTypes.Select(type => new VehicleTypeDataModel
            {
                Id = type.Id,
                Name = type.Name
            }) as ICollection<VehicleTypeDataModel>)!
        });
}