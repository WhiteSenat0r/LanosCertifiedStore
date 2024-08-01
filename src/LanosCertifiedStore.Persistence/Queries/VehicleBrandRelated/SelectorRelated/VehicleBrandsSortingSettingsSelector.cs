using System.Linq.Expressions;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace LanosCertifiedStore.Persistence.Queries.VehicleBrandRelated.SelectorRelated;

internal sealed class VehicleBrandsSortingSettingsSelector : 
    QuerySortingSettingsSelectorBase<VehicleBrand>
{
    private protected override IReadOnlyDictionary<string, Expression<Func<VehicleBrand, object>>> 
        GetMappedSortingExpressions()
    {
        Expression<Func<VehicleBrand, object>> expression = vehicleBrand => vehicleBrand.Name;

        return new Dictionary<string, Expression<Func<VehicleBrand, object>>>
        {
            { "name-asc", expression },
            { "name-desc", expression },
            { string.Empty, expression }
        };
    }
}