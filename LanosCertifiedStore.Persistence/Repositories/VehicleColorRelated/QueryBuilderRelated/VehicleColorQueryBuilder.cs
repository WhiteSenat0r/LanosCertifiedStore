using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Domain.Entities.VehicleRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.VehicleColorRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.VehicleColorRelated.QueryBuilderRelated;

internal sealed class VehicleColorQueryBuilder(
    VehicleColorSelectionProfiles colorSelectionProfiles,
    VehicleColorFilteringCriteria colorFilteringCriteria)
    : BaseQueryBuilder<VehicleColorSelectionProfile,
        VehicleColor,
        VehicleColor,
        IVehicleColorFilteringRequestParameters>(
        colorSelectionProfiles,
        colorFilteringCriteria)
{
    private protected override VehicleColorSortingSettings GetQuerySortingSettings(
        IFilteringRequestParameters<VehicleColor>? filteringRequestParameters)
    {
        if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
        {
            return new VehicleColorSortingSettings
            {
                OrderByAscendingExpression = VehicleColorSortingTypes.Options["default"]
            };
        }

        var settings = new VehicleColorSortingSettings();

        if (filteringRequestParameters.SortingType.Contains("-asc"))
        {
            settings.OrderByAscendingExpression = VehicleColorSortingTypes.Options
                [filteringRequestParameters.SortingType];
        }
        else if (filteringRequestParameters.SortingType.Contains("-desc"))
        {
            settings.OrderByDescendingExpression = VehicleColorSortingTypes.Options
                [filteringRequestParameters.SortingType];
        }

        return settings;
    }
}