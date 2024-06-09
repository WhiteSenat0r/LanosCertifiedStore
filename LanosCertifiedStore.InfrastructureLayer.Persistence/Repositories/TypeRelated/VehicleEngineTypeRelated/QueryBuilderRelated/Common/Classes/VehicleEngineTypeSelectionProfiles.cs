using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Enums.RequestParametersRelated;
using Domain.Enums.RequestParametersRelated.TypeRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleEngineTypeRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleEngineTypeSelectionProfiles : 
    BaseSelectionProfiles<VehicleEngineTypeSelectionProfile, VehicleEngineType, VehicleEngineTypeDataModel>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleEngineTypeDataModel>, IQueryable<VehicleEngineTypeDataModel>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleEngineTypeDataModel> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleEngineTypeDataModel> inputQueryable,
        IFilteringRequestParameters<VehicleEngineType>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleEngineTypeDataModel> GetDefaultProfileQueryable(
        IQueryable<VehicleEngineTypeDataModel> queryable) =>
        queryable.Select(vehicleEngineType => new VehicleEngineTypeDataModel
        {
            Id = vehicleEngineType.Id,
            Name = vehicleEngineType.Name,
        });
}