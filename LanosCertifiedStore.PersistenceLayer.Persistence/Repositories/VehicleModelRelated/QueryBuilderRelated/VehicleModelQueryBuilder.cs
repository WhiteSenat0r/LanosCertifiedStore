using Domain.Contracts.RepositoryRelated;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation;
using Persistence.Repositories.VehicleModelRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.VehicleModelRelated.QueryBuilderRelated;

internal class VehicleModelQueryBuilder(
    VehicleModelSelectionProfiles selectionProfiles,
    VehicleModelFilteringCriteria vehicleFilteringCriteria)
    : BaseQueryBuilder<VehicleModelSelectionProfile,
        VehicleModel,
        VehicleModelDataModel,
        IVehicleModelFilteringRequestParameters>(
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