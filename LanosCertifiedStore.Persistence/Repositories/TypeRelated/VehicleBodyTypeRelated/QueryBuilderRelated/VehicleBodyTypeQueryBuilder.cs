using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated.TypeRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Persistence.Entities.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.TypeRelated.VehicleBodyTypeRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.TypeRelated.VehicleBodyTypeRelated.QueryBuilderRelated;

internal sealed class VehicleBodyTypeQueryBuilder(
    VehicleBodyTypeSelectionProfiles selectionProfiles,
    VehicleBodyTypeFilteringCriteria typeFilteringCriteria)
    : BaseQueryBuilder<VehicleBodyTypeSelectionProfile,
        VehicleBodyType,
        VehicleBodyTypeEntity,
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