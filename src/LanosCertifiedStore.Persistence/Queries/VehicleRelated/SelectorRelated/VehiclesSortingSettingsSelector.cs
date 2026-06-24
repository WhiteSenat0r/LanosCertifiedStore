using System.Linq.Expressions;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;

namespace LanosCertifiedStore.Persistence.Queries.VehicleRelated.SelectorRelated;

internal sealed class VehiclesSortingSettingsSelector : IQuerySortingSettingsSelector<Vehicle>
{
    public (Expression<Func<Vehicle, object>> SortingSettings, bool IsAscending) GetSortingSettings(
        IFilteringRequestParameters<Vehicle> filteringRequestParameters)
    {
        return (vehicle => vehicle.CreatedAt, false);
    }
}
