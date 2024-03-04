using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation.Common;

namespace Persistence.Repositories.VehicleColorRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleColorSelectionProfiles : 
    BaseSelectionProfiles<VehicleColorSelectionProfile, VehicleColor, VehicleColorDataModel>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleColorDataModel>, IQueryable<VehicleColorDataModel>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleColorDataModel> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleColorDataModel> inputQueryable,
        IFilteringRequestParameters<VehicleColor>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleColorDataModel> GetDefaultProfileQueryable(
        IQueryable<VehicleColorDataModel> queryable) =>
        queryable.Select(vehicleColor => new VehicleColorDataModel
        {
            Id = vehicleColor.Id,
            Name = vehicleColor.Name,
            HexValue = vehicleColor.HexValue
        });
}