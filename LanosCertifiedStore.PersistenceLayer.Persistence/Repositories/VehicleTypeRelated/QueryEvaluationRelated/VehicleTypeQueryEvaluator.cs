using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation;
using Persistence.Repositories.VehicleTypeRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleTypeRelated.QueryEvaluationRelated;

internal class VehicleTypeQueryEvaluator(
    IEnumerable<Expression<Func<VehicleTypeDataModel, object>>> includedAspects,
    IFilteringRequestParameters<VehicleType>? filteringRequestParameters,
    DbSet<VehicleTypeDataModel> dataModels,
    VehicleTypeFilteringCriteria typeFilteringCriteria)
    : BaseQueryEvaluator<VehicleType, VehicleTypeDataModel>(
        includedAspects,
        filteringRequestParameters,
        dataModels,
        typeFilteringCriteria)
{
    private protected override VehicleTypeSortingSettings GetQuerySortingSettings()
    {
        if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
            return new VehicleTypeSortingSettings
            {
                OrderByAscendingExpression = VehicleTypeSortingTypes.Options["default"]
            };

        var settings = new VehicleTypeSortingSettings();

        if (filteringRequestParameters.SortingType.Contains("-asc"))
            settings.OrderByAscendingExpression = VehicleTypeSortingTypes.Options
                [filteringRequestParameters.SortingType];
        else if (filteringRequestParameters.SortingType.Contains("-desc"))
            settings.OrderByDescendingExpression = VehicleTypeSortingTypes.Options
                [filteringRequestParameters.SortingType];
        
        return settings;
    }
}