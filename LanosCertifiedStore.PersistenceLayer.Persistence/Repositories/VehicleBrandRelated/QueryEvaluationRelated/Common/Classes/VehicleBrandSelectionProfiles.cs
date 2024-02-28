using Domain.Contracts.RepositoryRelated;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation.Common;

namespace Persistence.Repositories.VehicleBrandRelated.QueryEvaluationRelated.Common.Classes;

internal class VehicleBrandSelectionProfiles : 
    BaseSelectionProfiles<VehicleBrandSelectionProfile, VehicleBrand, VehicleBrandDataModel>
{
    private readonly Dictionary<VehicleBrandSelectionProfile,
            Func<IQueryable<VehicleBrandDataModel>, IQueryable<VehicleBrandDataModel>>>
        _mappedProfiles = new()
        {
            { VehicleBrandSelectionProfile.Default, GetCatalogProfileQueryable },
            { VehicleBrandSelectionProfile.Catalog, GetCatalogProfileQueryable },
            { VehicleBrandSelectionProfile.Single, GetSingleProfileQueryable },
        };

    public override IQueryable<VehicleBrandDataModel> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleBrandDataModel> inputQueryable,
        IFilteringRequestParameters<VehicleBrand>? requestParameters = null)
    {
        if (requestParameters is null) 
            return _mappedProfiles[VehicleBrandSelectionProfile.Default](inputQueryable);
        
        var brandRequestParams = requestParameters as IVehicleBrandFilteringRequestParameters;

        return _mappedProfiles[brandRequestParams!.SelectionProfile](inputQueryable);
    }

    private static IQueryable<VehicleBrandDataModel> GetCatalogProfileQueryable(
        IQueryable<VehicleBrandDataModel> queryable) =>
        queryable.Select(vehicleBrand => new VehicleBrandDataModel
        {
            Id = vehicleBrand.Id,
            Name = vehicleBrand.Name
        });
    
    private static IQueryable<VehicleBrandDataModel> GetSingleProfileQueryable(
        IQueryable<VehicleBrandDataModel> queryable) =>
        queryable.Select(vehicleBrand => new VehicleBrandDataModel
        {
            Id = vehicleBrand.Id,
            Name = vehicleBrand.Name,
            Models = (vehicleBrand.Models.Select(vehicleModel => new VehicleModelDataModel
            {
                Id = vehicleModel.Id,
                Name = vehicleModel.Name
            }) as ICollection<VehicleModelDataModel>)!
        });
}