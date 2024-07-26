using System.Linq.Expressions;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace LanosCertifiedStore.Persistence.Queries.VehicleModelRelated.SelectorRelated;

internal sealed class VehicleModelsSortingSettingsSelector : QuerySortingSettingsSelectorBase<VehicleModel>
{
    private protected override IReadOnlyDictionary<string, Expression<Func<VehicleModel, object>>> 
        GetMappedSortingExpressions()
    {
        Expression<Func<VehicleModel, object>> expression = vehicleModel => vehicleModel.Name;

        return new Dictionary<string, Expression<Func<VehicleModel, object>>>
        {
            { "name-asc", expression },
            { "name-desc", expression },
            { string.Empty, expression }
        };
    }
}