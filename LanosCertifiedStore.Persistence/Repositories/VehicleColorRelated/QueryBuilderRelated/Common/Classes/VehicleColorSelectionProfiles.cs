using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Domain.Models.VehicleRelated.Classes;
using Persistence.Entities.VehicleRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehicleColorRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleColorSelectionProfiles : 
    BaseSelectionProfiles<VehicleColorSelectionProfile, VehicleColor, VehicleColorEntity>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleColorEntity>, IQueryable<VehicleColorEntity>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleColorEntity> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleColorEntity> inputQueryable,
        IFilteringRequestParameters<VehicleColor>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleColorEntity> GetDefaultProfileQueryable(
        IQueryable<VehicleColorEntity> queryable) =>
        queryable.Select(vehicleColor => new VehicleColorEntity
        {
            Id = vehicleColor.Id,
            Name = vehicleColor.Name,
            HexValue = vehicleColor.HexValue
        });
}