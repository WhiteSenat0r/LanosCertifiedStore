using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Domain.Entities.VehicleRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehicleColorRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleColorSelectionProfiles : 
    BaseSelectionProfiles<VehicleColorSelectionProfile, VehicleColor, VehicleColor>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleColor>, IQueryable<VehicleColor>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleColor> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleColor> inputQueryable,
        IFilteringRequestParameters<VehicleColor>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleColor> GetDefaultProfileQueryable(
        IQueryable<VehicleColor> queryable) =>
        queryable.Select(vehicleColor => new VehicleColor
        {
            Id = vehicleColor.Id,
            Name = vehicleColor.Name,
            HexValue = vehicleColor.HexValue
        });
}