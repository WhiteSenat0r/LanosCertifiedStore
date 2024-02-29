using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation;
using Persistence.Repositories.VehicleRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleRelated.QueryEvaluationRelated;

internal class VehicleQueryEvaluator(
    VehicleSelectionProfiles selectionProfiles,
    VehicleFilteringCriteria vehicleFilteringCriteria)
    : BaseQueryEvaluator<VehicleSelectionProfile, Vehicle, VehicleDataModel>(
        selectionProfiles,
        vehicleFilteringCriteria)
{
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
}