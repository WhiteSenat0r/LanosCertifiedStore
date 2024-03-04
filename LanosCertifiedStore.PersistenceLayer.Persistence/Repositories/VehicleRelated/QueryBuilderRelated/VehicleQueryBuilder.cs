using Domain.Contracts.RepositoryRelated;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation;
using Persistence.Repositories.VehicleRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.VehicleRelated.QueryBuilderRelated;

internal class VehicleQueryBuilder(
    VehicleSelectionProfiles selectionProfiles,
    VehicleFilteringCriteria vehicleFilteringCriteria)
    : BaseQueryBuilder<VehicleSelectionProfile,
        Vehicle,
        VehicleDataModel,
        IVehicleFilteringRequestParameters>(
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