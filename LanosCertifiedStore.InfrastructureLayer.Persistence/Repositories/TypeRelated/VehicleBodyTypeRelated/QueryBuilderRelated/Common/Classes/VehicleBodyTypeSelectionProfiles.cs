using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Enums.RequestParametersRelated;
using Domain.Enums.RequestParametersRelated.TypeRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleBodyTypeRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleBodyTypeSelectionProfiles : 
    BaseSelectionProfiles<VehicleBodyTypeSelectionProfile, VehicleBodyType, VehicleBodyTypeDataModel>
{
    private readonly Dictionary<VehicleColorSelectionProfile,
            Func<IQueryable<VehicleBodyTypeDataModel>, IQueryable<VehicleBodyTypeDataModel>>>
        _mappedProfiles = new()
        {
            { VehicleColorSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleBodyTypeDataModel> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleBodyTypeDataModel> inputQueryable,
        IFilteringRequestParameters<VehicleBodyType>? requestParameters = null) =>
        _mappedProfiles[VehicleColorSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleBodyTypeDataModel> GetDefaultProfileQueryable(
        IQueryable<VehicleBodyTypeDataModel> queryable) =>
        queryable.Select(vehicleBodyType => new VehicleBodyTypeDataModel
        {
            Id = vehicleBodyType.Id,
            Name = vehicleBodyType.Name,
        });
}