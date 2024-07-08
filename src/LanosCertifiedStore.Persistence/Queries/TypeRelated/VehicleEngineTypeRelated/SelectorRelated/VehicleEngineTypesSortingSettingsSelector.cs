using System.Linq.Expressions;
using Domain.Entities.VehicleRelated.TypeRelated;
using Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace Persistence.Queries.TypeRelated.VehicleEngineTypeRelated.SelectorRelated;

internal sealed class VehicleEngineTypesSortingSettingsSelector : QuerySortingSettingsSelectorBase<VehicleEngineType>
{
    private protected override IReadOnlyDictionary<string, Expression<Func<VehicleEngineType, object>>>
        GetMappedSortingExpressions()
    {
        Expression<Func<VehicleEngineType, object>> expression = vehicleBodyType => vehicleBodyType.Name;

        return new Dictionary<string, Expression<Func<VehicleEngineType, object>>>
        {
            { "name-asc", expression },
            { "name-desc", expression },
            { string.Empty, expression }
        };
    }
}