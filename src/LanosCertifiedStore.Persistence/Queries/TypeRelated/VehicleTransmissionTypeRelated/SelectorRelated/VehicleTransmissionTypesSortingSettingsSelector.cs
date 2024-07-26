using System.Linq.Expressions;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace LanosCertifiedStore.Persistence.Queries.TypeRelated.VehicleTransmissionTypeRelated.SelectorRelated;

internal sealed class VehicleTransmissionTypesSortingSettingsSelector : 
    QuerySortingSettingsSelectorBase<VehicleTransmissionType>
{
    private protected override IReadOnlyDictionary<string, Expression<Func<VehicleTransmissionType, object>>>
        GetMappedSortingExpressions()
    {
        Expression<Func<VehicleTransmissionType, object>> expression = 
            vehicleTransmissionType => vehicleTransmissionType.Name;

        return new Dictionary<string, Expression<Func<VehicleTransmissionType, object>>>
        {
            { "name-asc", expression },
            { "name-desc", expression },
            { string.Empty, expression }
        };
    }
}