using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Enums.RequestParametersRelated;
using Domain.Enums.RequestParametersRelated.TypeRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleTransmissionTypeRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleTransmissionTypeSelectionProfiles : 
    BaseSelectionProfiles<VehicleTransmissionTypeSelectionProfile,
        VehicleTransmissionType,
        VehicleTransmissionTypeDataModel>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleTransmissionTypeDataModel>, IQueryable<VehicleTransmissionTypeDataModel>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleTransmissionTypeDataModel> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleTransmissionTypeDataModel> inputQueryable,
        IFilteringRequestParameters<VehicleTransmissionType>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleTransmissionTypeDataModel> GetDefaultProfileQueryable(
        IQueryable<VehicleTransmissionTypeDataModel> queryable) =>
        queryable.Select(vehicleTransmissionType => new VehicleTransmissionTypeDataModel
        {
            Id = vehicleTransmissionType.Id,
            Name = vehicleTransmissionType.Name,
        });
}