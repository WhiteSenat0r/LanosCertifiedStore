using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;
using LanosCertifiedStore.Persistence.Queries.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LanosCertifiedStore.Persistence.Queries.VehicleRelated.QueryRelated;

public sealed class PriceRangeQuery(
    ApplicationDatabaseContext context,
    IQueryFilteringCriteriaSelector<Vehicle> filteringCriteriaSelector)
{
    public async Task<PriceRangeDto> Execute(
        IVehicleFilteringRequestParameters vehicleFilteringRequestParameters,
        CancellationToken cancellationToken)
    {
        var queryable = context.Set<Vehicle>().AsQueryable();

        queryable = queryable.GetQueryWithAppliedFilters(vehicleFilteringRequestParameters, filteringCriteriaSelector);

        var priceRange = await queryable
            .Select(v => v.Prices.OrderByDescending(p => p.IssueDate).First().Value)
            .GroupBy(x => 1)
            .Select(g => new PriceRangeDto(
                g.Min(),
                g.Max()
            ))
            .FirstOrDefaultAsync();

        return priceRange ?? new PriceRangeDto(0, 0); // Or handle null case as appropriate
    }
}