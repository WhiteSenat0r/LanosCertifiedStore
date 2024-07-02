using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleTypeRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleTypeSelectionProfiles : 
    BaseSelectionProfiles<VehicleTypeSelectionProfile, VehicleType, VehicleType>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleType>, IQueryable<VehicleType>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleType> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleType> inputQueryable,
        IFilteringRequestParameters<VehicleType>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleType> GetDefaultProfileQueryable(
        IQueryable<VehicleType> queryable) =>
        queryable.Select(vehicleType => new VehicleType
        {
            Id = vehicleType.Id,
            Name = vehicleType.Name,
        });
}