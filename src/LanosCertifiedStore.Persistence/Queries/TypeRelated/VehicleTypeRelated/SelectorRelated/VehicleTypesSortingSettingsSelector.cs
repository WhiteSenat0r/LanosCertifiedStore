using System.Linq.Expressions;
using Domain.Entities.VehicleRelated.TypeRelated;
using Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace Persistence.Queries.TypeRelated.VehicleTypeRelated.SelectorRelated;

internal sealed class VehicleTypesSortingSettingsSelector : 
    QuerySortingSettingsSelectorBase<VehicleType>
{
    private protected override IReadOnlyDictionary<string, Expression<Func<VehicleType, object>>> 
        GetMappedSortingExpressions()
    {
        Expression<Func<VehicleType, object>> expression = vehicleBrand => vehicleBrand.Name;

        return new Dictionary<string, Expression<Func<VehicleType, object>>>
        {
            { "name-asc", expression },
            { "name-desc", expression },
            { string.Empty, expression }
        };
    }
}