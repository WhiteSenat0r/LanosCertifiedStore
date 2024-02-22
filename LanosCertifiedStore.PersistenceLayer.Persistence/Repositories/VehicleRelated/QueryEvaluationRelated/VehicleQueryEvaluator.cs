using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation;
using Persistence.Repositories.VehicleRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleRelated.QueryEvaluationRelated;

internal class VehicleQueryEvaluator(
    IEnumerable<Expression<Func<VehicleDataModel, object>>> includedAspects,
    IFilteringRequestParameters<Vehicle>? filteringRequestParameters,
    DbSet<VehicleDataModel> dataModels,
    VehicleFilteringCriteria vehicleFilteringCriteria)
    : BaseQueryEvaluator<Vehicle, VehicleDataModel>(
        includedAspects,
        filteringRequestParameters,
        dataModels,
        vehicleFilteringCriteria)
{
    private protected override VehicleSortingSettings GetQuerySortingSettings()
    {
        if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
            return new VehicleSortingSettings
            {
                OrderByAscendingExpression = VehicleSortingTypes.Options["default"]
            };

        var settings = new VehicleSortingSettings();

        if (filteringRequestParameters.SortingType.Contains("-asc"))
            settings.OrderByAscendingExpression = VehicleSortingTypes.Options
                [filteringRequestParameters.SortingType];
        else if (filteringRequestParameters.SortingType.Contains("-desc"))
            settings.OrderByDescendingExpression = VehicleSortingTypes.Options
                [filteringRequestParameters.SortingType];
        
        return settings;
    }
}