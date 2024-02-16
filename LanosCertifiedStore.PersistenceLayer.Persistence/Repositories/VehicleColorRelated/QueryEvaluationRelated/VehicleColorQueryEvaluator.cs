using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels;
using Persistence.QueryEvaluation;
using Persistence.Repositories.VehicleColorRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleColorRelated.QueryEvaluationRelated;

internal class VehicleColorQueryEvaluator(
    IEnumerable<Expression<Func<VehicleColorDataModel, object>>> includedAspects,
    IFilteringRequestParameters<VehicleColor>? filteringRequestParameters,
    DbSet<VehicleColorDataModel> dataModels,
    VehicleColorFilteringCriteria colorFilteringCriteria)
    : BaseQueryEvaluator<VehicleColor, VehicleColorDataModel>(
        includedAspects,
        filteringRequestParameters,
        dataModels,
        colorFilteringCriteria)
{
    private protected override VehicleColorSortingSettings GetQuerySortingSettings()
    {
        if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
            return new VehicleColorSortingSettings
            {
                OrderByAscendingExpression = VehicleColorSortingTypes.Options["default"]
            };

        var settings = new VehicleColorSortingSettings();

        if (filteringRequestParameters.SortingType.Contains("-asc"))
            settings.OrderByAscendingExpression = VehicleColorSortingTypes.Options
                [filteringRequestParameters.SortingType];
        else if (filteringRequestParameters.SortingType.Contains("-desc"))
            settings.OrderByDescendingExpression = VehicleColorSortingTypes.Options
                [filteringRequestParameters.SortingType];
        
        return settings;
    }
}