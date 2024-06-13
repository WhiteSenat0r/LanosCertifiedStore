using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Domain.Models.VehicleRelated.Classes;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.VehicleImageRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.VehicleImageRelated.QueryBuilderRelated;

internal sealed class VehicleImageQueryBuilder(
    VehicleImageSelectionProfiles imageSelectionProfile,
    VehicleImageFilteringCriteria imageFilteringCriteria)
    : BaseQueryBuilder<VehicleImageSelectionProfile,
        VehicleImage,
        VehicleImageDataModel,
        IVehicleImageFilteringRequestParameters>(
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