using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Domain.Models.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence.Entities.VehicleRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.VehicleRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.VehicleRelated.QueryBuilderRelated;

internal sealed class VehicleQueryBuilder(
    VehicleSelectionProfiles selectionProfiles,
    VehicleFilteringCriteria vehicleFilteringCriteria)
    : BaseQueryBuilder<VehicleSelectionProfile,
        Vehicle,
        VehicleEntity,
        IVehicleFilteringRequestParameters>(
        selectionProfiles,
        vehicleFilteringCriteria)
{
    internal Task<IDictionary<string, decimal>> GetPriceRange(DbSet<VehicleEntity> dataModels,
        IFilteringRequestParameters<Vehicle>? filteringRequestParameters = null!)
    {
        var range = new Dictionary<string, decimal>();
        
        var vehicles = dataModels.AsQueryable();
        vehicles = GetQueryWithAppliedFilters(filteringRequestParameters, vehicles);

        if (vehicles.IsNullOrEmpty()) return Task.FromResult<IDictionary<string, decimal>>(range);
        
        vehicles = OrderQueryByPrice(vehicles);
        vehicles = GetQueryWithAddedSelects(filteringRequestParameters, vehicles);
        
        GetRangeParts(range, vehicles);

        return Task.FromResult<IDictionary<string, decimal>>(range);
    }
    
    private protected override VehicleSortingSettings GetQuerySortingSettings(
        IFilteringRequestParameters<Vehicle>? filteringRequestParameters)
    {
        if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
            return new VehicleSortingSettings
            {
                OrderByAscendingExpression = VehicleSortingTypes.Options["default"]
            };

        var settings = new VehicleSortingSettings();

        if (filteringRequestParameters.SortingType.Contains("-asc"))
            settings.OrderByAscendingExpression = VehicleSortingTypes.Options
                [filteringRequestParameters.SortingType];
        else if (filteringRequestParameters.SortingType.Contains("-desc"))
            settings.OrderByDescendingExpression = VehicleSortingTypes.Options
                [filteringRequestParameters.SortingType];
        
        return settings;
    }

    private void GetRangeParts(IDictionary<string, decimal> range, IQueryable<VehicleEntity> vehicles)
    {
        range.Add("lowerPriceRange", GetRangePart(vehicles, vehicle => vehicle.First()));
        range.Add("upperPriceRange", GetRangePart(vehicles, vehicle => vehicle.Last()));
    }

    private decimal GetRangePart(IQueryable<VehicleEntity> vehicles,
        Func<IQueryable<VehicleEntity>, VehicleEntity> vehicleSelector)
    {
        var selectedVehicle = vehicleSelector(vehicles);
        var selectedPrice = selectedVehicle.Prices.First();
        
        return selectedPrice.Value;
    }

    private IOrderedQueryable<VehicleEntity> OrderQueryByPrice(IQueryable<VehicleEntity> vehicles) =>
        vehicles.OrderBy(
            v => v.Prices.OrderByDescending(
                p => p.IssueDate).FirstOrDefault()!.Value);
}