using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels;
using Persistence.QueryEvaluation;
using Persistence.Repositories.VehicleImageRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleImageRelated.QueryEvaluationRelated;

internal class VehicleImageQueryEvaluator(
    IEnumerable<Expression<Func<VehicleImageDataModel, object>>> includedAspects,
    IFilteringRequestParameters<VehicleImage>? filteringRequestParameters,
    DbSet<VehicleImageDataModel> dataModels,
    VehicleImageFilteringCriteria imageFilteringCriteria)
    : BaseQueryEvaluator<VehicleImage, VehicleImageDataModel>(
        includedAspects,
        filteringRequestParameters,
        dataModels,
        imageFilteringCriteria)
{
    private protected override VehicleImageSortingSettings GetQuerySortingSettings() =>
        new()
        {
            OrderByAscendingExpression = VehicleImageSortingTypes.Options["default"]
        };
}