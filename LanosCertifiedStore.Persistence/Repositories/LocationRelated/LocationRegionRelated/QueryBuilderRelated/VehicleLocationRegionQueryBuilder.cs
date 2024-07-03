using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated.LocationRelated;
using Application.Enums.RequestParametersRelated.LocationRelated;
using Domain.Entities.VehicleRelated.LocationRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.LocationRelated.LocationRegionRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.LocationRelated.LocationRegionRelated.QueryBuilderRelated;

internal sealed class VehicleLocationRegionQueryBuilder(
    VehicleLocationRegionSelectionProfiles selectionProfiles,
    VehicleLocationRegionFilteringCriteria typeFilteringCriteria)
    : BaseQueryBuilder<VehicleLocationRegionSelectionProfile,
        VehicleLocationRegion,
        VehicleLocationRegion,
        IVehicleLocationRegionFilteringRequestParameters>(
        selectionProfiles,
        typeFilteringCriteria)
{
    private protected override VehicleLocationRegionSortingSettings GetQuerySortingSettings(
        IFilteringRequestParameters<VehicleLocationRegion>? filteringRequestParameters)
    {
        if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
        {
            return new VehicleLocationRegionSortingSettings
            {
                OrderByAscendingExpression = VehicleLocationRegionSortingTypes.Options["default"]
            };
        }

        var settings = new VehicleLocationRegionSortingSettings();

        if (filteringRequestParameters.SortingType.Contains("-asc"))
        {
            settings.OrderByAscendingExpression = VehicleLocationRegionSortingTypes.Options
                [filteringRequestParameters.SortingType];
        }
        else if (filteringRequestParameters.SortingType.Contains("-desc"))
        {
            settings.OrderByDescendingExpression = VehicleLocationRegionSortingTypes.Options
                [filteringRequestParameters.SortingType];
        }

        return settings;
    }
}