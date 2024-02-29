using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation;
using Persistence.Repositories.VehiclePriceRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehiclePriceRelated.QueryEvaluationRelated;

internal class VehiclePriceQueryEvaluator(
    VehiclePriceSelectionProfiles selectionProfiles,
    VehiclePriceFilteringCriteria priceFilteringCriteria)
    : BaseQueryEvaluator<VehiclePriceSelectionProfile, VehiclePrice, VehiclePriceDataModel>(
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