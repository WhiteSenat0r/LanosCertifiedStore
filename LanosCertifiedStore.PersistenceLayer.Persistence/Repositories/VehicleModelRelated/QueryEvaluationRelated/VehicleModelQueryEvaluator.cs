using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation;
using Persistence.Repositories.VehicleModelRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleModelRelated.QueryEvaluationRelated;

internal class VehicleModelQueryEvaluator(
    IEnumerable<Expression<Func<VehicleModelDataModel, object>>> includedAspects,
    IFilteringRequestParameters<VehicleModel>? filteringRequestParameters,
    DbSet<VehicleModelDataModel> dataModels,
    VehicleModelFilteringCriteria vehicleFilteringCriteria)
    : BaseQueryEvaluator<VehicleModel, VehicleModelDataModel>(
        includedAspects,
        filteringRequestParameters,
        dataModels,
        vehicleFilteringCriteria)
{
    private protected override VehicleModelSortingSettings GetQuerySortingSettings()
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