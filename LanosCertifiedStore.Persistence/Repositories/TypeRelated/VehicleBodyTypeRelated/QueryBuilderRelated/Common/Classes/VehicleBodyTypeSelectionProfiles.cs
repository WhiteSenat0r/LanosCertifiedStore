using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Persistence.Entities.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleBodyTypeRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleBodyTypeSelectionProfiles : 
    BaseSelectionProfiles<VehicleBodyTypeSelectionProfile, VehicleBodyType, VehicleBodyTypeEntity>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleBodyTypeEntity>, IQueryable<VehicleBodyTypeEntity>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleBodyTypeEntity> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleBodyTypeEntity> inputQueryable,
        IFilteringRequestParameters<VehicleBodyType>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleBodyTypeEntity> GetDefaultProfileQueryable(
        IQueryable<VehicleBodyTypeEntity> queryable) =>
        queryable.Select(vehicleBodyType => new VehicleBodyTypeEntity
        {
            Id = vehicleBodyType.Id,
            Name = vehicleBodyType.Name,
        });
}