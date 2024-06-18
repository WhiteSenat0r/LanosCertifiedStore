using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated.LocationRelated;
using Application.Enums.RequestParametersRelated.LocationRelated;
using Domain.Models.VehicleRelated.Classes.LocationRelated;
using Persistence.Entities.VehicleRelated.LocationRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.LocationRelated.LocationAreaRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.LocationRelated.LocationAreaRelated.QueryBuilderRelated;

internal sealed class VehicleLocationAreaQueryBuilder(
    VehicleLocationAreaSelectionProfiles selectionProfiles,
    VehicleLocationAreaFilteringCriteria typeFilteringCriteria)
    : BaseQueryBuilder<VehicleLocationAreaSelectionProfile,
        VehicleLocationArea,
        VehicleLocationAreaEntity,
        IVehicleLocationAreaFilteringRequestParameters>(
        selectionProfiles,
        typeFilteringCriteria)
{
    private protected override VehicleLocationAreaSortingSettings GetQuerySortingSettings(
        IFilteringRequestParameters<VehicleLocationArea>? filteringRequestParameters)
    {
        if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
            return new VehicleLocationAreaSortingSettings
            {
                OrderByAscendingExpression = VehicleLocationAreaSortingTypes.Options["default"]
            };

        var settings = new VehicleLocationAreaSortingSettings();

        if (filteringRequestParameters.SortingType.Contains("-asc"))
            settings.OrderByAscendingExpression = VehicleLocationAreaSortingTypes.Options
                [filteringRequestParameters.SortingType];
        else if (filteringRequestParameters.SortingType.Contains("-desc"))
            settings.OrderByDescendingExpression = VehicleLocationAreaSortingTypes.Options
                [filteringRequestParameters.SortingType];
        
        return settings;
    }
}