using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Enums.RequestParametersRelated;
using Domain.Enums.RequestParametersRelated.LocationRelated;
using Persistence.DataModels.VehicleRelated.LocationRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.LocationRelated.LocationTownRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleLocationTownSelectionProfiles : 
    BaseSelectionProfiles<VehicleLocationTownSelectionProfile, VehicleLocationTown, VehicleLocationTownDataModel>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleLocationTownDataModel>, IQueryable<VehicleLocationTownDataModel>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleLocationTownDataModel> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleLocationTownDataModel> inputQueryable,
        IFilteringRequestParameters<VehicleLocationTown>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleLocationTownDataModel> GetDefaultProfileQueryable(
        IQueryable<VehicleLocationTownDataModel> queryable) =>
        queryable.Select(vehicleType => new VehicleLocationTownDataModel
        {
            Id = vehicleType.Id,
            Name = vehicleType.Name,
        });
}