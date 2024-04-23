using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Enums.RequestParametersRelated;
using Domain.Enums.RequestParametersRelated.LocationRelated;
using Persistence.DataModels.VehicleRelated.LocationRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.LocationRelated.LocationAreaRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleLocationAreaSelectionProfiles : 
    BaseSelectionProfiles<VehicleLocationAreaSelectionProfile, VehicleLocationArea, VehicleLocationAreaDataModel>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleLocationAreaDataModel>, IQueryable<VehicleLocationAreaDataModel>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleLocationAreaDataModel> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleLocationAreaDataModel> inputQueryable,
        IFilteringRequestParameters<VehicleLocationArea>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleLocationAreaDataModel> GetDefaultProfileQueryable(
        IQueryable<VehicleLocationAreaDataModel> queryable) =>
        queryable.Select(vehicleType => new VehicleLocationAreaDataModel
        {
            Id = vehicleType.Id,
            Name = vehicleType.Name,
        });
}