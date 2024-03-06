using Domain.Contracts.RepositoryRelated;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation;
using Persistence.Repositories.VehicleTypeRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.VehicleTypeRelated.QueryBuilderRelated;

internal sealed class VehicleTypeQueryBuilder(
    VehicleTypeSelectionProfiles selectionProfiles,
    VehicleTypeFilteringCriteria typeFilteringCriteria)
    : BaseQueryBuilder<VehicleTypeSelectionProfile,
        VehicleType,
        VehicleTypeDataModel,
        IVehicleTypeFilteringRequestParameters>(
        selectionProfiles,
        typeFilteringCriteria)
{
    private protected override VehicleTypeSortingSettings GetQuerySortingSettings(IFilteringRequestParameters<VehicleType>? filteringRequestParameters)
    {
        if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
            return new VehicleTypeSortingSettings
            {
                OrderByAscendingExpression = VehicleTypeSortingTypes.Options["default"]
            };

        var settings = new VehicleTypeSortingSettings();

        if (filteringRequestParameters.SortingType.Contains("-asc"))
            settings.OrderByAscendingExpression = VehicleTypeSortingTypes.Options
                [filteringRequestParameters.SortingType];
        else if (filteringRequestParameters.SortingType.Contains("-desc"))
            settings.OrderByDescendingExpression = VehicleTypeSortingTypes.Options
                [filteringRequestParameters.SortingType];
        
        return settings;
    }
}