using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleEngineTypeRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleEngineTypeSelectionProfiles : 
    BaseSelectionProfiles<VehicleEngineTypeSelectionProfile, VehicleEngineType, VehicleEngineType>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleEngineType>, IQueryable<VehicleEngineType>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleEngineType> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleEngineType> inputQueryable,
        IFilteringRequestParameters<VehicleEngineType>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleEngineType> GetDefaultProfileQueryable(
        IQueryable<VehicleEngineType> queryable) =>
        queryable.Select(vehicleEngineType => new VehicleEngineType
        {
            Id = vehicleEngineType.Id,
            Name = vehicleEngineType.Name,
        });
}