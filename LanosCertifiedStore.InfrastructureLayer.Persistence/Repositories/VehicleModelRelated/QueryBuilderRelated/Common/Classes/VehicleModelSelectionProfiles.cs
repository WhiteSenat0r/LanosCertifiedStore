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
            // TODO
            // { VehicleModelSelectionProfile.Single, GetSingleProfileQueryable },
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
    
    // TODO
    // private static IQueryable<VehicleModelDataModel> GetSingleProfileQueryable(
    //     IQueryable<VehicleModelDataModel> queryable) =>
    //     queryable.Select(vehicleModel => new VehicleModelDataModel
    //     {
    //         Id = vehicleModel.Id,
    //         Name = vehicleModel.Name,
    //         VehicleBrand = new VehicleBrandDataModel
    //         {
    //             Id = vehicleModel.VehicleBrand.Id,
    //             Name = vehicleModel.VehicleBrand.Name
    //         },
    //         VehicleType = (vehicleModel.VehicleType.Select(type => new VehicleTypeDataModel
    //         {
    //             Id = type.Id,
    //             Name = type.Name
    //         }) as ICollection<VehicleTypeDataModel>)!
    //     });
}