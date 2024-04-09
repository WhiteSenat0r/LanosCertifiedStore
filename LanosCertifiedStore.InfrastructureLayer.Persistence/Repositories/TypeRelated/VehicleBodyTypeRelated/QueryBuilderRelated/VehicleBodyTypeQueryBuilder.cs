using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Enums.RequestParametersRelated.TypeRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.TypeRelated.VehicleBodyTypeRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.TypeRelated.VehicleBodyTypeRelated.QueryBuilderRelated;

internal sealed class VehicleBodyTypeQueryBuilder(
    VehicleBodyTypeSelectionProfiles selectionProfiles,
    VehicleBodyTypeFilteringCriteria typeFilteringCriteria)
    : BaseQueryBuilder<VehicleBodyTypeSelectionProfile,
        VehicleBodyType,
        VehicleBodyTypeDataModel,
        IVehicleBodyTypeFilteringRequestParameters>(
        selectionProfiles,
        typeFilteringCriteria)
{
    private protected override VehicleBodyTypeSortingSettings GetQuerySortingSettings(
        IFilteringRequestParameters<VehicleBodyType>? filteringRequestParameters)
    {
        if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
            return new VehicleBodyTypeSortingSettings
            {
                OrderByAscendingExpression = VehicleBodyTypeSortingTypes.Options["default"]
            };

        var settings = new VehicleBodyTypeSortingSettings();

        if (filteringRequestParameters.SortingType.Contains("-asc"))
            settings.OrderByAscendingExpression = VehicleBodyTypeSortingTypes.Options
                [filteringRequestParameters.SortingType];
        else if (filteringRequestParameters.SortingType.Contains("-desc"))
            settings.OrderByDescendingExpression = VehicleBodyTypeSortingTypes.Options
                [filteringRequestParameters.SortingType];
        
        return settings;
    }
}