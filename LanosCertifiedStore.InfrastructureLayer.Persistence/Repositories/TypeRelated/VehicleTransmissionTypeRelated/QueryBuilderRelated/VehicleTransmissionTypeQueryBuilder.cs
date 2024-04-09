using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Enums.RequestParametersRelated.TypeRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.TypeRelated.VehicleTransmissionTypeRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.TypeRelated.VehicleTransmissionTypeRelated.QueryBuilderRelated;

internal sealed class VehicleTransmissionTypeQueryBuilder(
    VehicleTransmissionTypeSelectionProfiles selectionProfiles,
    VehicleTransmissionTypeFilteringCriteria typeFilteringCriteria)
    : BaseQueryBuilder<VehicleTransmissionTypeSelectionProfile,
        VehicleTransmissionType,
        VehicleTransmissionTypeDataModel,
        IVehicleTransmissionTypeFilteringRequestParameters>(
        selectionProfiles,
        typeFilteringCriteria)
{
    private protected override VehicleTransmissionTypeSortingSettings GetQuerySortingSettings(
        IFilteringRequestParameters<VehicleTransmissionType>? filteringRequestParameters)
    {
        if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
            return new VehicleTransmissionTypeSortingSettings
            {
                OrderByAscendingExpression = VehicleTransmissionTypeSortingTypes.Options["default"]
            };

        var settings = new VehicleTransmissionTypeSortingSettings();

        if (filteringRequestParameters.SortingType.Contains("-asc"))
            settings.OrderByAscendingExpression = VehicleTransmissionTypeSortingTypes.Options
                [filteringRequestParameters.SortingType];
        else if (filteringRequestParameters.SortingType.Contains("-desc"))
            settings.OrderByDescendingExpression = VehicleTransmissionTypeSortingTypes.Options
                [filteringRequestParameters.SortingType];
        
        return settings;
    }
}