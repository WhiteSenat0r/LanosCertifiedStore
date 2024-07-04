using System.Linq.Expressions;
using Domain.Entities.VehicleRelated;
using Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace Persistence.Queries.VehicleColorRelated.SelectorRelated;

internal sealed class VehicleColorsSortingSettingsSelector : QuerySortingSettingsSelectorBase<VehicleColor>
{
    private protected override IReadOnlyDictionary<string, Expression<Func<VehicleColor, object>>>
        GetMappedSortingExpressions()
    {
        Expression<Func<VehicleColor, object>> expression = vehicleBrand => vehicleBrand.Name;

        return new Dictionary<string, Expression<Func<VehicleColor, object>>>
        {
            { "name-asc", expression },
            { "name-desc", expression },
            { string.Empty, expression }
        };
    }
}