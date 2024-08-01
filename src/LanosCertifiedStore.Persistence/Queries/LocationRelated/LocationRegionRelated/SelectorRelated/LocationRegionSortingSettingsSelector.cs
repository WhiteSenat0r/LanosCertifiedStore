using System.Linq.Expressions;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace LanosCertifiedStore.Persistence.Queries.LocationRelated.LocationRegionRelated.SelectorRelated;

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