using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation;
using Persistence.Repositories.VehicleImageRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleImageRelated.QueryEvaluationRelated;

internal class VehicleImageQueryEvaluator(
    VehicleImageSelectionProfiles imageSelectionProfile,
    VehicleImageFilteringCriteria imageFilteringCriteria)
    : BaseQueryEvaluator<VehicleImageSelectionProfile, VehicleImage, VehicleImageDataModel>(
        imageSelectionProfile,
        imageFilteringCriteria)
{
    private protected override VehicleImageSortingSettings GetQuerySortingSettings(
        IFilteringRequestParameters<VehicleImage>? filteringRequestParameters) =>
        new()
        {
            OrderByAscendingExpression = VehicleImageSortingTypes.Options["default"]
        };
}