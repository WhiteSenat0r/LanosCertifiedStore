using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Persistence.Entities.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleDrivetrainTypeRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleDrivetrainTypeSelectionProfiles : 
    BaseSelectionProfiles<VehicleDrivetrainTypeSelectionProfile, VehicleDrivetrainType, VehicleDrivetrainTypeEntity>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleDrivetrainTypeEntity>, IQueryable<VehicleDrivetrainTypeEntity>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleDrivetrainTypeEntity> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleDrivetrainTypeEntity> inputQueryable,
        IFilteringRequestParameters<VehicleDrivetrainType>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleDrivetrainTypeEntity> GetDefaultProfileQueryable(
        IQueryable<VehicleDrivetrainTypeEntity> queryable) =>
        queryable.Select(vehicleDrivetrainType => new VehicleDrivetrainTypeEntity
        {
            Id = vehicleDrivetrainType.Id,
            Name = vehicleDrivetrainType.Name,
        });
}