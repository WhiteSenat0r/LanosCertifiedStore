using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated.LocationRelated;
using Application.Enums.RequestParametersRelated.LocationRelated;
using Domain.Models.VehicleRelated.Classes.LocationRelated;
using Persistence.Entities.VehicleRelated.LocationRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.LocationRelated.LocationTownRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.LocationRelated.LocationTownRelated.QueryBuilderRelated;

internal sealed class VehicleLocationTownQueryBuilder(
    VehicleLocationTownSelectionProfiles selectionProfiles,
    VehicleLocationTownFilteringCriteria typeFilteringCriteria)
    : BaseQueryBuilder<VehicleLocationTownSelectionProfile,
        VehicleLocationTown,
        VehicleLocationTownEntity,
        IVehicleLocationTownFilteringRequestParameters>(
        selectionProfiles,
        typeFilteringCriteria)
{
    private protected override VehicleLocationTownSortingSettings GetQuerySortingSettings(
        IFilteringRequestParameters<VehicleLocationTown>? filteringRequestParameters)
    {
        if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
            return new VehicleLocationTownSortingSettings
            {
                OrderByAscendingExpression = VehicleLocationTownSortingTypes.Options["default"]
            };

        var settings = new VehicleLocationTownSortingSettings();

        if (filteringRequestParameters.SortingType.Contains("-asc"))
            settings.OrderByAscendingExpression = VehicleLocationTownSortingTypes.Options
                [filteringRequestParameters.SortingType];
        else if (filteringRequestParameters.SortingType.Contains("-desc"))
            settings.OrderByDescendingExpression = VehicleLocationTownSortingTypes.Options
                [filteringRequestParameters.SortingType];
        
        return settings;
    }
}