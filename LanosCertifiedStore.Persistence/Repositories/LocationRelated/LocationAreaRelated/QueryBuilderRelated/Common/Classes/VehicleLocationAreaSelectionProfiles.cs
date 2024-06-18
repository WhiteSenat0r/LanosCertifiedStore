using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Application.Enums.RequestParametersRelated.LocationRelated;
using Domain.Models.VehicleRelated.Classes.LocationRelated;
using Persistence.Entities.VehicleRelated.LocationRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.LocationRelated.LocationAreaRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleLocationAreaSelectionProfiles : 
    BaseSelectionProfiles<VehicleLocationAreaSelectionProfile, VehicleLocationArea, VehicleLocationAreaEntity>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleLocationAreaEntity>, IQueryable<VehicleLocationAreaEntity>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleLocationAreaEntity> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleLocationAreaEntity> inputQueryable,
        IFilteringRequestParameters<VehicleLocationArea>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleLocationAreaEntity> GetDefaultProfileQueryable(
        IQueryable<VehicleLocationAreaEntity> queryable) =>
        queryable.Select(vehicleType => new VehicleLocationAreaEntity
        {
            Id = vehicleType.Id,
            Name = vehicleType.Name,
        });
}