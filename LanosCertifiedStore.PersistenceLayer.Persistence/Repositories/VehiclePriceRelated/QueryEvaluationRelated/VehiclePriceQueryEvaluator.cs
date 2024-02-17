using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels;
using Persistence.QueryEvaluation;
using Persistence.Repositories.VehiclePriceRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehiclePriceRelated.QueryEvaluationRelated;

internal class VehiclePriceQueryEvaluator(
    IEnumerable<Expression<Func<VehiclePriceDataModel, object>>> includedAspects,
    IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters,
    DbSet<VehiclePriceDataModel> dataModels,
    VehiclePriceFilteringCriteria priceFilteringCriteria)
    : BaseQueryEvaluator<VehiclePrice, VehiclePriceDataModel>(
        includedAspects,
        filteringRequestParameters,
        dataModels,
        priceFilteringCriteria)
{
    private protected override VehiclePriceSortingSettings GetQuerySortingSettings()
    {
        if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
            return new VehiclePriceSortingSettings
            {
                OrderByAscendingExpression = VehiclePriceSortingTypes.Options["default"]
            };

        var settings = new VehiclePriceSortingSettings();

        if (filteringRequestParameters.SortingType.Contains("-asc"))
            settings.OrderByAscendingExpression = VehiclePriceSortingTypes.Options
                [filteringRequestParameters.SortingType];
        else if (filteringRequestParameters.SortingType.Contains("-desc"))
            settings.OrderByDescendingExpression = VehiclePriceSortingTypes.Options
                [filteringRequestParameters.SortingType];
        
        return settings;
    }
}