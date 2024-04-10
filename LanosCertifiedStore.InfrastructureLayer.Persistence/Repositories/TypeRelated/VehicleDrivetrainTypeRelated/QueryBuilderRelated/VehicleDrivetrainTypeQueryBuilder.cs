using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Enums.RequestParametersRelated.TypeRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.TypeRelated.VehicleDrivetrainTypeRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.TypeRelated.VehicleDrivetrainTypeRelated.QueryBuilderRelated;

internal sealed class VehicleDrivetrainTypeQueryBuilder(
    VehicleDrivetrainTypeSelectionProfiles selectionProfiles,
    VehicleDrivetrainTypeFilteringCriteria typeFilteringCriteria)
    : BaseQueryBuilder<VehicleDrivetrainTypeSelectionProfile,
        VehicleDrivetrainType,
        VehicleDrivetrainTypeDataModel,
        IVehicleDrivetrainTypeFilteringRequestParameters>(
        selectionProfiles,
        typeFilteringCriteria)
{
    private protected override VehicleDrivetrainTypeSortingSettings GetQuerySortingSettings(
        IFilteringRequestParameters<VehicleDrivetrainType>? filteringRequestParameters)
    {
        if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
            return new VehicleDrivetrainTypeSortingSettings
            {
                OrderByAscendingExpression = VehicleDrivetrainTypeSortingTypes.Options["default"]
            };

        var settings = new VehicleDrivetrainTypeSortingSettings();

        if (filteringRequestParameters.SortingType.Contains("-asc"))
            settings.OrderByAscendingExpression = VehicleDrivetrainTypeSortingTypes.Options
                [filteringRequestParameters.SortingType];
        else if (filteringRequestParameters.SortingType.Contains("-desc"))
            settings.OrderByDescendingExpression = VehicleDrivetrainTypeSortingTypes.Options
                [filteringRequestParameters.SortingType];
        
        return settings;
    }
}