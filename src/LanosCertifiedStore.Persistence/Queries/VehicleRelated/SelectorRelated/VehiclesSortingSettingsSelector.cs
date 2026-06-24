using System.Linq.Expressions;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace LanosCertifiedStore.Persistence.Queries.VehicleRelated.SelectorRelated;

internal sealed class VehiclesSortingSettingsSelector : QuerySortingSettingsSelectorBase<Vehicle>
{
    private protected override IReadOnlyDictionary<string, Expression<Func<Vehicle, object>>>
        GetMappedSortingExpressions()
    {
        Expression<Func<Vehicle, object>> createdAtExpression = vehicle => vehicle.CreatedAt;

        return new Dictionary<string, Expression<Func<Vehicle, object>>>
        {
            { "createdat-asc", createdAtExpression },
            { "createdat-desc", createdAtExpression },
            { string.Empty, createdAtExpression }
        };
    }
}
