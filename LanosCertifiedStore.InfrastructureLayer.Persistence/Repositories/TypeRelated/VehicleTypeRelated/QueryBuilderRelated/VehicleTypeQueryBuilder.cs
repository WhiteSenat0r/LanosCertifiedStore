﻿using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Enums.RequestParametersRelated.TypeRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.TypeRelated.VehicleTypeRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.TypeRelated.VehicleTypeRelated.QueryBuilderRelated;

internal sealed class VehicleTypeQueryBuilder(
    VehicleTypeSelectionProfiles selectionProfiles,
    VehicleTypeFilteringCriteria typeFilteringCriteria)
    : BaseQueryBuilder<VehicleTypeSelectionProfile,
        VehicleType,
        VehicleTypeDataModel,
        IVehicleTypeFilteringRequestParameters>(
        selectionProfiles,
        typeFilteringCriteria)
{
    private protected override VehicleTypeSortingSettings GetQuerySortingSettings(IFilteringRequestParameters<VehicleType>? filteringRequestParameters)
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