using System.Linq.Expressions;
using Domain.Models.VehicleRelated.Classes;
using Persistence.Entities.VehicleRelated;
using Persistence.Queries.Common.Classes.QueryRelated;

namespace Persistence.Queries.VehicleBrandRelated.SelectorRelated;

internal sealed class VehicleBrandsSortingSettingsSelector : 
    QuerySortingSettingsSelectorBase<VehicleBrand, VehicleBrandEntity>
{
    private protected override IReadOnlyDictionary<string, Expression<Func<VehicleBrandEntity, object>>> 
        GetMappedSortingExpressions()
    {
        Expression<Func<VehicleBrandEntity, object>> expression = vehicleBrand => vehicleBrand.Name;

        return new Dictionary<string, Expression<Func<VehicleBrandEntity, object>>>
        {
            { "name-asc", expression },
            { "name-desc", expression },
            { string.Empty, expression }
        };
    }
}