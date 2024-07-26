using System.Linq.Expressions;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace LanosCertifiedStore.Persistence.Queries.TypeRelated.VehicleDrivetrainTypeRelated.SelectorRelated;

internal sealed class VehicleDrivetrainTypesSortingSettingsSelector
    : QuerySortingSettingsSelectorBase<VehicleDrivetrainType>
{
    private protected override IReadOnlyDictionary<string, Expression<Func<VehicleDrivetrainType, object>>>
        GetMappedSortingExpressions()
    {
        Expression<Func<VehicleDrivetrainType, object>> expression = drivetrainType => drivetrainType.Name;

        return new Dictionary<string, Expression<Func<VehicleDrivetrainType, object>>>
        {
            { "name-asc", expression },
            { "name-desc", expression },
            { string.Empty, expression }
        };
    }
}