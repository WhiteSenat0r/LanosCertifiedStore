using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation.Common;

namespace Persistence.Repositories.VehicleTypeRelated.QueryEvaluationRelated.Common.Classes;

internal class VehicleTypeSelectionProfiles : 
    BaseSelectionProfiles<VehicleTypeSelectionProfile, VehicleType, VehicleTypeDataModel>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleTypeDataModel>, IQueryable<VehicleTypeDataModel>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleTypeDataModel> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleTypeDataModel> inputQueryable,
        IFilteringRequestParameters<VehicleType>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleTypeDataModel> GetDefaultProfileQueryable(
        IQueryable<VehicleTypeDataModel> queryable) =>
        queryable.Select(vehicleType => new VehicleTypeDataModel
        {
            Id = vehicleType.Id,
            Name = vehicleType.Name,
        });
}