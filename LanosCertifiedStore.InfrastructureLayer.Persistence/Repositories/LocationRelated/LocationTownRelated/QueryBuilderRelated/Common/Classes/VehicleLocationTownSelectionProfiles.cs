using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Application.Enums.RequestParametersRelated.LocationRelated;
using Domain.Models.VehicleRelated.Classes.LocationRelated;
using Persistence.Entities.VehicleRelated.LocationRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.LocationRelated.LocationTownRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleLocationTownSelectionProfiles : 
    BaseSelectionProfiles<VehicleLocationTownSelectionProfile, VehicleLocationTown, VehicleLocationTownEntity>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleLocationTownEntity>, IQueryable<VehicleLocationTownEntity>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleLocationTownEntity> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleLocationTownEntity> inputQueryable,
        IFilteringRequestParameters<VehicleLocationTown>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleLocationTownEntity> GetDefaultProfileQueryable(
        IQueryable<VehicleLocationTownEntity> queryable) =>
        queryable.Select(vehicleType => new VehicleLocationTownEntity
        {
            Id = vehicleType.Id,
            Name = vehicleType.Name,
        });
}