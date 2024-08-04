using System.Linq.Expressions;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace LanosCertifiedStore.Persistence.Queries.VehicleRelated.SelectorRelated;

internal sealed class VehicleSortingSettingsSelector : QuerySortingSettingsSelectorBase<Vehicle>
{
    private protected override IReadOnlyDictionary<string, Expression<Func<Vehicle, object>>>
        GetMappedSortingExpressions()
    {
        return new Dictionary<string, Expression<Func<Vehicle, object>>>
        {
            { "created-at-asc", vehicle => vehicle.CreatedAt },
            { "created-at-desc", vehicle => vehicle.CreatedAt },
            {
                "price-asc",
                vehicle => vehicle.Prices.OrderByDescending(p => p.IssueDate).Select(p => p.Value).FirstOrDefault()
            },
            {
                "price-desc",
                vehicle => vehicle.Prices.OrderByDescending(p => p.IssueDate).Select(p => p.Value).FirstOrDefault()
            },
            { "production-year-asc", vehicle => vehicle.ProductionYear },
            { "production-year-desc", vehicle => vehicle.ProductionYear },
            { string.Empty, vehicle => vehicle.CreatedAt }
        };
    }
}