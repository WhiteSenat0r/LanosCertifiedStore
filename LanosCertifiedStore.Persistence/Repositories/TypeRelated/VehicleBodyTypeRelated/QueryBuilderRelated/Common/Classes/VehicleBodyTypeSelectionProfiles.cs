using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleBodyTypeRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleBodyTypeSelectionProfiles : 
    BaseSelectionProfiles<VehicleBodyTypeSelectionProfile, VehicleBodyType, VehicleBodyType>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleBodyType>, IQueryable<VehicleBodyType>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleBodyType> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleBodyType> inputQueryable,
        IFilteringRequestParameters<VehicleBodyType>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleBodyType> GetDefaultProfileQueryable(
        IQueryable<VehicleBodyType> queryable) =>
        queryable.Select(vehicleBodyType => new VehicleBodyType
        {
            Id = vehicleBodyType.Id,
            Name = vehicleBodyType.Name,
        });
}