using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RequestParametersRelated.LocationRelated;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Enums.RequestParametersRelated.LocationRelated;
using Persistence.DataModels.VehicleRelated.LocationRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.LocationRelated.LocationTownRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.LocationRelated.LocationTownRelated.QueryBuilderRelated;

internal sealed class VehicleLocationTownQueryBuilder(
    VehicleLocationTownSelectionProfiles selectionProfiles,
    VehicleLocationTownFilteringCriteria typeFilteringCriteria)
    : BaseQueryBuilder<VehicleLocationTownSelectionProfile,
        VehicleLocationTown,
        VehicleLocationTownDataModel,
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