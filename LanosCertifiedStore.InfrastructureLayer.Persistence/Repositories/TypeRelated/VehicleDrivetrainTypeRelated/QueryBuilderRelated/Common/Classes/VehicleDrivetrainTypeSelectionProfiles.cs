using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Enums.RequestParametersRelated;
using Domain.Enums.RequestParametersRelated.TypeRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleDrivetrainTypeRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleDrivetrainTypeSelectionProfiles : 
    BaseSelectionProfiles<VehicleDrivetrainTypeSelectionProfile, VehicleDrivetrainType, VehicleDrivetrainTypeDataModel>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleDrivetrainTypeDataModel>, IQueryable<VehicleDrivetrainTypeDataModel>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleDrivetrainTypeDataModel> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleDrivetrainTypeDataModel> inputQueryable,
        IFilteringRequestParameters<VehicleDrivetrainType>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleDrivetrainTypeDataModel> GetDefaultProfileQueryable(
        IQueryable<VehicleDrivetrainTypeDataModel> queryable) =>
        queryable.Select(vehicleDrivetrainType => new VehicleDrivetrainTypeDataModel
        {
            Id = vehicleDrivetrainType.Id,
            Name = vehicleDrivetrainType.Name,
        });
}