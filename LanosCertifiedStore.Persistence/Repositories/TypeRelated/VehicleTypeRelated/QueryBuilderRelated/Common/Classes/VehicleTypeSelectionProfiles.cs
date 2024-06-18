using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Persistence.Entities.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleTypeRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleTypeSelectionProfiles : 
    BaseSelectionProfiles<VehicleTypeSelectionProfile, VehicleType, VehicleTypeEntity>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleTypeEntity>, IQueryable<VehicleTypeEntity>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleTypeEntity> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleTypeEntity> inputQueryable,
        IFilteringRequestParameters<VehicleType>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleTypeEntity> GetDefaultProfileQueryable(
        IQueryable<VehicleTypeEntity> queryable) =>
        queryable.Select(vehicleType => new VehicleTypeEntity
        {
            Id = vehicleType.Id,
            Name = vehicleType.Name,
        });
}