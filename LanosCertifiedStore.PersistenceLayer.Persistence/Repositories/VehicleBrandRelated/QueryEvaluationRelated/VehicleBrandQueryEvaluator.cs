using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation;
using Persistence.Repositories.VehicleBrandRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleBrandRelated.QueryEvaluationRelated;

internal class VehicleBrandQueryEvaluator(
    VehicleBrandSelectionProfiles selectionProfiles,
    IFilteringRequestParameters<VehicleBrand>? filteringRequestParameters,
    DbSet<VehicleBrandDataModel> dataModels,
    VehicleBrandFilteringCriteria brandFilteringCriteria)
    : BaseQueryEvaluator<VehicleBrandSelectionProfile, VehicleBrand, VehicleBrandDataModel>(
        selectionProfiles,
        filteringRequestParameters,
        dataModels,
        brandFilteringCriteria)
{
    private protected override VehicleBrandSortingSettings GetQuerySortingSettings()
    {
        if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
            return new VehicleBrandSortingSettings
            {
                OrderByAscendingExpression = VehicleBrandSortingTypes.Options["default"]
            };

        var settings = new VehicleBrandSortingSettings();

        if (filteringRequestParameters.SortingType.Contains("-asc"))
            settings.OrderByAscendingExpression = VehicleBrandSortingTypes.Options
                [filteringRequestParameters.SortingType];
        else if (filteringRequestParameters.SortingType.Contains("-desc"))
            settings.OrderByDescendingExpression = VehicleBrandSortingTypes.Options
                [filteringRequestParameters.SortingType];
        
        return settings;
    }
}