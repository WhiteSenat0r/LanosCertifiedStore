using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleDrivetrainTypeRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleDrivetrainTypeSelectionProfiles : 
    BaseSelectionProfiles<VehicleDrivetrainTypeSelectionProfile, VehicleDrivetrainType, VehicleDrivetrainType>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleDrivetrainType>, IQueryable<VehicleDrivetrainType>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleDrivetrainType> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleDrivetrainType> inputQueryable,
        IFilteringRequestParameters<VehicleDrivetrainType>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleDrivetrainType> GetDefaultProfileQueryable(
        IQueryable<VehicleDrivetrainType> queryable) =>
        queryable.Select(vehicleDrivetrainType => new VehicleDrivetrainType
        {
            Id = vehicleDrivetrainType.Id,
            Name = vehicleDrivetrainType.Name,
        });
}