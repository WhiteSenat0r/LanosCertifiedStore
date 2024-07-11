using System.Linq.Expressions;
using Domain.Entities.VehicleRelated.LocationRelated;
using Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace Persistence.Queries.LocationRelated.LocationRegionRelated.SelectorRelated;

internal sealed class LocationRegionSortingSettingsSelector : QuerySortingSettingsSelectorBase<VehicleLocationRegion>
{
    private protected override IReadOnlyDictionary<string, Expression<Func<VehicleLocationRegion, object>>>
        GetMappedSortingExpressions()
    {
        Expression<Func<VehicleLocationRegion, object>> expression = locationRegion => locationRegion.Name;

        return new Dictionary<string, Expression<Func<VehicleLocationRegion, object>>>
        {
            { "name-asc", expression },
            { "name-desc", expression },
            { string.Empty, expression }
        };
    }
}