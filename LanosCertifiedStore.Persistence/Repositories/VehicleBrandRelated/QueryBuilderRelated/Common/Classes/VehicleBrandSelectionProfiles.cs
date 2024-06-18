using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Domain.Models.VehicleRelated.Classes;
using Persistence.Entities.VehicleRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehicleBrandRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleBrandSelectionProfiles : 
    BaseSelectionProfiles<VehicleBrandSelectionProfile, VehicleBrand, VehicleBrandEntity>
{
    private readonly Dictionary<VehicleBrandSelectionProfile,
            Func<IQueryable<VehicleBrandEntity>, IQueryable<VehicleBrandEntity>>>
        _mappedProfiles = new()
        {
            { VehicleBrandSelectionProfile.Default, GetCatalogProfileQueryable },
            { VehicleBrandSelectionProfile.Single, GetSingleProfileQueryable },
        };

    public override IQueryable<VehicleBrandEntity> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleBrandEntity> inputQueryable,
        IFilteringRequestParameters<VehicleBrand>? requestParameters = null)
    {
        if (requestParameters is null) 
            return _mappedProfiles[VehicleBrandSelectionProfile.Default](inputQueryable);
        
        var brandRequestParams = requestParameters as IVehicleBrandFilteringRequestParameters;

        return _mappedProfiles[brandRequestParams!.SelectionProfile](inputQueryable);
    }

    private static IQueryable<VehicleBrandEntity> GetCatalogProfileQueryable(
        IQueryable<VehicleBrandEntity> queryable) =>
        queryable.Select(vehicleBrand => new VehicleBrandEntity
        {
            Id = vehicleBrand.Id,
            Name = vehicleBrand.Name
        });
    
    private static IQueryable<VehicleBrandEntity> GetSingleProfileQueryable(
        IQueryable<VehicleBrandEntity> queryable) =>
        queryable.Select(vehicleBrand => new VehicleBrandEntity
        {
            Id = vehicleBrand.Id,
            Name = vehicleBrand.Name,
            Models = (vehicleBrand.Models.Select(vehicleModel => new VehicleModelEntity
            {
                Id = vehicleModel.Id,
                Name = vehicleModel.Name
            }) as ICollection<VehicleModelEntity>)!
        });
}