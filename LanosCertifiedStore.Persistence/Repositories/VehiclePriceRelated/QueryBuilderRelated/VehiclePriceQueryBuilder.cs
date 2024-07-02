using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Domain.Entities.VehicleRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.VehiclePriceRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.VehiclePriceRelated.QueryBuilderRelated;

internal sealed class VehiclePriceQueryBuilder(
    VehiclePriceSelectionProfiles selectionProfiles,
    VehiclePriceFilteringCriteria priceFilteringCriteria)
    : BaseQueryBuilder<VehiclePriceSelectionProfile,
        VehiclePrice,
        VehiclePrice,
        IVehiclePriceFilteringRequestParameters>(
        selectionProfiles,
        priceFilteringCriteria)
{
    private protected override VehiclePriceSortingSettings GetQuerySortingSettings(
        IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters)
    {
        if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
            return new VehiclePriceSortingSettings
            {
                OrderByAscendingExpression = VehiclePriceSortingTypes.Options["default"]
            };

        var settings = new VehiclePriceSortingSettings();

        if (filteringRequestParameters.SortingType.Contains("-asc"))
            settings.OrderByAscendingExpression = VehiclePriceSortingTypes.Options
                [filteringRequestParameters.SortingType];
        else if (filteringRequestParameters.SortingType.Contains("-desc"))
            settings.OrderByDescendingExpression = VehiclePriceSortingTypes.Options
                [filteringRequestParameters.SortingType];
        
        return settings;
    }
}