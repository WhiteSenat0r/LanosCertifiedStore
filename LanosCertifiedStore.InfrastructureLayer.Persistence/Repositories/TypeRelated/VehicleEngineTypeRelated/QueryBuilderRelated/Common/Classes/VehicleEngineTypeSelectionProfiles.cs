using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Persistence.Entities.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleEngineTypeRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleEngineTypeSelectionProfiles : 
    BaseSelectionProfiles<VehicleEngineTypeSelectionProfile, VehicleEngineType, VehicleEngineTypeEntity>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleEngineTypeEntity>, IQueryable<VehicleEngineTypeEntity>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleEngineTypeEntity> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleEngineTypeEntity> inputQueryable,
        IFilteringRequestParameters<VehicleEngineType>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleEngineTypeEntity> GetDefaultProfileQueryable(
        IQueryable<VehicleEngineTypeEntity> queryable) =>
        queryable.Select(vehicleEngineType => new VehicleEngineTypeEntity
        {
            Id = vehicleEngineType.Id,
            Name = vehicleEngineType.Name,
        });
}