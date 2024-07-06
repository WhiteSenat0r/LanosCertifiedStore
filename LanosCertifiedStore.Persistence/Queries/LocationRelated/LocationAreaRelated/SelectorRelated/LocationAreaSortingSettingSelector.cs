using System.Linq.Expressions;
using Domain.Entities.VehicleRelated.LocationRelated;
using Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace Persistence.Queries.LocationRelated.LocationAreaRelated.SelectorRelated;

internal sealed class LocationAreaSortingSettingSelector : QuerySortingSettingsSelectorBase<VehicleLocationArea>
{
    private protected override IReadOnlyDictionary<string, Expression<Func<VehicleLocationArea, object>>>
        GetMappedSortingExpressions()
    {
        Expression<Func<VehicleLocationArea, object>> expression = locationArea => locationArea.Name;

        return new Dictionary<string, Expression<Func<VehicleLocationArea, object>>>
        {
            { "name-asc", expression },
            { "name-desc", expression },
            { string.Empty, expression }
        };
    }
}