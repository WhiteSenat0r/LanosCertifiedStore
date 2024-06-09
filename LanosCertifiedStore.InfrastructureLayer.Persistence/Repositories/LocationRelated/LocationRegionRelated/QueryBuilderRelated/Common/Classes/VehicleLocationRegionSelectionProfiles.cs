using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Enums.RequestParametersRelated;
using Domain.Enums.RequestParametersRelated.LocationRelated;
using Persistence.DataModels.VehicleRelated.LocationRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.LocationRelated.LocationRegionRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleLocationRegionSelectionProfiles : 
    BaseSelectionProfiles<VehicleLocationRegionSelectionProfile, VehicleLocationRegion, VehicleLocationRegionDataModel>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleLocationRegionDataModel>, IQueryable<VehicleLocationRegionDataModel>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleLocationRegionDataModel> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleLocationRegionDataModel> inputQueryable,
        IFilteringRequestParameters<VehicleLocationRegion>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleLocationRegionDataModel> GetDefaultProfileQueryable(
        IQueryable<VehicleLocationRegionDataModel> queryable) =>
        queryable.Select(vehicleType => new VehicleLocationRegionDataModel
        {
            Id = vehicleType.Id,
            Name = vehicleType.Name,
        });
}