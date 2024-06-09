using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RequestParametersRelated.LocationRelated;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Enums.RequestParametersRelated.LocationRelated;
using Persistence.DataModels.VehicleRelated.LocationRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.LocationRelated.LocationRegionRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.LocationRelated.LocationRegionRelated.QueryBuilderRelated;

internal sealed class VehicleLocationRegionQueryBuilder(
    VehicleLocationRegionSelectionProfiles selectionProfiles,
    VehicleLocationRegionFilteringCriteria typeFilteringCriteria)
    : BaseQueryBuilder<VehicleLocationRegionSelectionProfile,
        VehicleLocationRegion,
        VehicleLocationRegionDataModel,
        IVehicleLocationRegionFilteringRequestParameters>(
        selectionProfiles,
        typeFilteringCriteria)
{
    private protected override VehicleLocationRegionSortingSettings GetQuerySortingSettings(
        IFilteringRequestParameters<VehicleLocationRegion>? filteringRequestParameters)
    {
        if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
            return new VehicleLocationRegionSortingSettings
            {
                OrderByAscendingExpression = VehicleLocationRegionSortingTypes.Options["default"]
            };

        var settings = new VehicleLocationRegionSortingSettings();

        if (filteringRequestParameters.SortingType.Contains("-asc"))
            settings.OrderByAscendingExpression = VehicleLocationRegionSortingTypes.Options
                [filteringRequestParameters.SortingType];
        else if (filteringRequestParameters.SortingType.Contains("-desc"))
            settings.OrderByDescendingExpression = VehicleLocationRegionSortingTypes.Options
                [filteringRequestParameters.SortingType];
        
        return settings;
    }
}