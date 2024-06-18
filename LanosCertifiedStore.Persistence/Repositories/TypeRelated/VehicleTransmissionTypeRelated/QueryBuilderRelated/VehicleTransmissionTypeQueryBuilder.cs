﻿using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated.TypeRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Persistence.Entities.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.TypeRelated.VehicleTransmissionTypeRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.TypeRelated.VehicleTransmissionTypeRelated.QueryBuilderRelated;

internal sealed class VehicleTransmissionTypeQueryBuilder(
    VehicleTransmissionTypeSelectionProfiles selectionProfiles,
    VehicleTransmissionTypeFilteringCriteria typeFilteringCriteria)
    : BaseQueryBuilder<VehicleTransmissionTypeSelectionProfile,
        VehicleTransmissionType,
        VehicleTransmissionTypeEntity,
        IVehicleTransmissionTypeFilteringRequestParameters>(
        selectionProfiles,
        typeFilteringCriteria)
{
    private protected override VehicleTransmissionTypeSortingSettings GetQuerySortingSettings(
        IFilteringRequestParameters<VehicleTransmissionType>? filteringRequestParameters)
    {
        if (string.IsNullOrEmpty(filteringRequestParameters!.SortingType))
            return new VehicleTransmissionTypeSortingSettings
            {
                OrderByAscendingExpression = VehicleTransmissionTypeSortingTypes.Options["default"]
            };

        var settings = new VehicleTransmissionTypeSortingSettings();

        if (filteringRequestParameters.SortingType.Contains("-asc"))
            settings.OrderByAscendingExpression = VehicleTransmissionTypeSortingTypes.Options
                [filteringRequestParameters.SortingType];
        else if (filteringRequestParameters.SortingType.Contains("-desc"))
            settings.OrderByDescendingExpression = VehicleTransmissionTypeSortingTypes.Options
                [filteringRequestParameters.SortingType];
        
        return settings;
    }
}