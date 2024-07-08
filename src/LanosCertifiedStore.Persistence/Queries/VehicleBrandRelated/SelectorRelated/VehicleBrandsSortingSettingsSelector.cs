using System.Linq.Expressions;
using Domain.Entities.VehicleRelated;
using Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace Persistence.Queries.VehicleBrandRelated.SelectorRelated;

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