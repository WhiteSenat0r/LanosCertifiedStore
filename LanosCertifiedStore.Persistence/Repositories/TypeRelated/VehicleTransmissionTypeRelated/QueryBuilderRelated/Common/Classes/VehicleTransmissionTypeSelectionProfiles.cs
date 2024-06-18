using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Persistence.Entities.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleTransmissionTypeRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleTransmissionTypeSelectionProfiles : 
    BaseSelectionProfiles<VehicleTransmissionTypeSelectionProfile,
        VehicleTransmissionType,
        VehicleTransmissionTypeEntity>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleTransmissionTypeEntity>, IQueryable<VehicleTransmissionTypeEntity>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleTransmissionTypeEntity> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleTransmissionTypeEntity> inputQueryable,
        IFilteringRequestParameters<VehicleTransmissionType>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleTransmissionTypeEntity> GetDefaultProfileQueryable(
        IQueryable<VehicleTransmissionTypeEntity> queryable) =>
        queryable.Select(vehicleTransmissionType => new VehicleTransmissionTypeEntity
        {
            Id = vehicleTransmissionType.Id,
            Name = vehicleTransmissionType.Name,
        });
}