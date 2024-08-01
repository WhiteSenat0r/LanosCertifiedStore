using System.Linq.Expressions;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace LanosCertifiedStore.Persistence.Queries.TypeRelated.VehicleEngineTypeRelated.SelectorRelated;

internal sealed class VehicleEngineTypesSortingSettingsSelector : QuerySortingSettingsSelectorBase<VehicleEngineType>
{
    private protected override IReadOnlyDictionary<string, Expression<Func<VehicleEngineType, object>>>
        GetMappedSortingExpressions()
    {
        Expression<Func<VehicleEngineType, object>> expression = vehicleBodyType => vehicleBodyType.Name;

        return new Dictionary<string, Expression<Func<VehicleEngineType, object>>>
        {
            { "name-asc", expression },
            { "name-desc", expression },
            { string.Empty, expression }
        };
    }
}