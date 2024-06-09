using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Enums.RequestParametersRelated.TypeRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.TypeRelated.VehicleEngineTypeRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.TypeRelated.VehicleEngineTypeRelated.QueryBuilderRelated;

internal sealed class VehicleEngineTypeQueryBuilder(
    VehicleEngineTypeSelectionProfiles selectionProfiles,
    VehicleEngineTypeFilteringCriteria typeFilteringCriteria)
    : BaseQueryBuilder<VehicleEngineTypeSelectionProfile,
        VehicleEngineType,
        VehicleEngineTypeDataModel,
        IVehicleEngineTypeFilteringRequestParameters>(
        selectionProfiles,
        typeFilteringCriteria)
{
    private protected override VehicleEngineTypeSortingSettings GetQuerySortingSettings(
        IFilteringRequestParameters<VehicleEngineType>? filteringRequestParameters)
    {
        if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
            return new VehicleEngineTypeSortingSettings
            {
                OrderByAscendingExpression = VehicleEngineTypeSortingTypes.Options["default"]
            };

        var settings = new VehicleEngineTypeSortingSettings();

        if (filteringRequestParameters.SortingType.Contains("-asc"))
            settings.OrderByAscendingExpression = VehicleEngineTypeSortingTypes.Options
                [filteringRequestParameters.SortingType];
        else if (filteringRequestParameters.SortingType.Contains("-desc"))
            settings.OrderByDescendingExpression = VehicleEngineTypeSortingTypes.Options
                [filteringRequestParameters.SortingType];
        
        return settings;
    }
}