using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation;
using Persistence.Repositories.VehicleModelRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleModelRelated.QueryEvaluationRelated;

internal class VehicleModelQueryEvaluator(
    VehicleModelSelectionProfiles selectionProfiles,
    VehicleModelFilteringCriteria vehicleFilteringCriteria)
    : BaseQueryEvaluator<VehicleModelSelectionProfile, VehicleModel, VehicleModelDataModel>(
        selectionProfiles,
        vehicleFilteringCriteria)
{
    private protected override VehicleModelSortingSettings GetQuerySortingSettings(
        IFilteringRequestParameters<VehicleModel>? filteringRequestParameters)
    {
        if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
            return new VehicleModelSortingSettings
            {
                OrderByAscendingExpression = VehicleModelSortingTypes.Options["default"]
            };

        var settings = new VehicleModelSortingSettings();

        if (filteringRequestParameters.SortingType.Contains("-asc"))
            settings.OrderByAscendingExpression = VehicleModelSortingTypes.Options
                [filteringRequestParameters.SortingType];
        else if (filteringRequestParameters.SortingType.Contains("-desc"))
            settings.OrderByDescendingExpression = VehicleModelSortingTypes.Options
                [filteringRequestParameters.SortingType];
        
        return settings;
    }
}