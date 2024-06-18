using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Domain.Models.VehicleRelated.Classes;
using Persistence.Entities.VehicleRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.VehicleModelRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.VehicleModelRelated.QueryBuilderRelated;

internal sealed class VehicleModelQueryBuilder(
    VehicleModelSelectionProfiles selectionProfiles,
    VehicleModelFilteringCriteria vehicleFilteringCriteria)
    : BaseQueryBuilder<VehicleModelSelectionProfile,
        VehicleModel,
        VehicleModelEntity,
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