using Domain.Contracts.RepositoryRelated;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation;
using Persistence.Repositories.VehiclePriceRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.VehiclePriceRelated.QueryBuilderRelated;

internal class VehiclePriceQueryBuilder(
    VehiclePriceSelectionProfiles selectionProfiles,
    VehiclePriceFilteringCriteria priceFilteringCriteria)
    : BaseQueryBuilder<VehiclePriceSelectionProfile,
        VehiclePrice,
        VehiclePriceDataModel,
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