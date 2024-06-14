using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Application.Enums.RequestParametersRelated.LocationRelated;
using Domain.Models.VehicleRelated.Classes.LocationRelated;
using Persistence.Entities.VehicleRelated.LocationRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.LocationRelated.LocationRegionRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleLocationRegionSelectionProfiles : 
    BaseSelectionProfiles<VehicleLocationRegionSelectionProfile, VehicleLocationRegion, VehicleLocationRegionEntity>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleLocationRegionEntity>, IQueryable<VehicleLocationRegionEntity>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleLocationRegionEntity> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleLocationRegionEntity> inputQueryable,
        IFilteringRequestParameters<VehicleLocationRegion>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleLocationRegionEntity> GetDefaultProfileQueryable(
        IQueryable<VehicleLocationRegionEntity> queryable) =>
        queryable.Select(vehicleType => new VehicleLocationRegionEntity
        {
            Id = vehicleType.Id,
            Name = vehicleType.Name,
        });
}