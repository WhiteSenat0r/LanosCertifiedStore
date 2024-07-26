using System.Linq.Expressions;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace LanosCertifiedStore.Persistence.Queries.LocationRelated.LocationTownRelated.SelectorRelated;

internal sealed class LocationTownSortingSettingsSelector : QuerySortingSettingsSelectorBase<VehicleLocationTown>
{
    private protected override IReadOnlyDictionary<string, Expression<Func<VehicleLocationTown, object>>>
        GetMappedSortingExpressions()
    {
        Expression<Func<VehicleLocationTown, object>> nameExpression = 
            locationTown => locationTown.Name;
        Expression<Func<VehicleLocationTown, object>> regionExpression = 
            locationTown => locationTown.LocationRegion.Name;
        Expression<Func<VehicleLocationTown, object>> townTypeExpression = 
            locationTown => locationTown.LocationRegion.Name;

        return new Dictionary<string, Expression<Func<VehicleLocationTown, object>>>
        {
            { "name-asc", nameExpression },
            { "name-desc", nameExpression },
            { "region-asc", regionExpression },
            { "region-desc", regionExpression },
            { "type-asc", townTypeExpression },
            { "type-desc", townTypeExpression },
            { string.Empty, nameExpression }
        };
    }
}