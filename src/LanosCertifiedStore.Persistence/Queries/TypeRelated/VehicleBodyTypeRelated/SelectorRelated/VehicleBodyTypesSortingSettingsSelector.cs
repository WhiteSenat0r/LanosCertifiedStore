using System.Linq.Expressions;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace LanosCertifiedStore.Persistence.Queries.TypeRelated.VehicleBodyTypeRelated.SelectorRelated;

internal sealed class VehicleBodyTypesSortingSettingsSelector : QuerySortingSettingsSelectorBase<VehicleBodyType>
{
    private protected override IReadOnlyDictionary<string, Expression<Func<VehicleBodyType, object>>>
        GetMappedSortingExpressions()
    {
        Expression<Func<VehicleBodyType, object>> expression = vehicleBodyType => vehicleBodyType.Name;

        return new Dictionary<string, Expression<Func<VehicleBodyType, object>>>
        {
            { "name-asc", expression },
            { "name-desc", expression },
            { string.Empty, expression }
        };
    }
}