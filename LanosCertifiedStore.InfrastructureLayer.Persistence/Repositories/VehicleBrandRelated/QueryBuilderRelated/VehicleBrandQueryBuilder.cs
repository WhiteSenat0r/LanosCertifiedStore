﻿using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.VehicleBrandRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.VehicleBrandRelated.QueryBuilderRelated;

internal sealed class VehicleBrandQueryBuilder(
    VehicleBrandSelectionProfiles selectionProfiles,
    VehicleBrandFilteringCriteria brandFilteringCriteria)
    : BaseQueryBuilder<VehicleBrandSelectionProfile,
        VehicleBrand,
        VehicleBrandDataModel,
        IVehicleBrandFilteringRequestParameters>(
        selectionProfiles,
        brandFilteringCriteria)
{
    private protected override VehicleBrandSortingSettings GetQuerySortingSettings(
        IFilteringRequestParameters<VehicleBrand>? filteringRequestParameters)
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