﻿using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleDrivetrainTypeRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehicleDrivetrainTypeFilteringCriteria : 
    BaseFilteringCriteria<VehicleDrivetrainType,
        VehicleDrivetrainTypeDataModel,
        IVehicleDrivetrainTypeFilteringRequestParameters>
{ 
    internal override Expression<Func<VehicleDrivetrainTypeDataModel, bool>> GetCriteria(
        IFilteringRequestParameters<VehicleDrivetrainType>? filteringRequestParameters)
    { 
        var vehicleDrivetrainTypeFilteringParameters = filteringRequestParameters 
            as IVehicleDrivetrainTypeFilteringRequestParameters;

        return vehicleDrivetrainType =>
            string.IsNullOrEmpty(vehicleDrivetrainTypeFilteringParameters!.Name)
            || vehicleDrivetrainType.Name.Equals(vehicleDrivetrainTypeFilteringParameters.Name);
    }
    
    private protected override void AddPredicateMethodsToList(
        IVehicleDrivetrainTypeFilteringRequestParameters requestParameters)
    {
        if (!string.IsNullOrEmpty(requestParameters.Name)) 
            PredicateDelegates.Add(GetNamePredicate);
    }

    private Expression<Func<VehicleDrivetrainTypeDataModel, bool>> GetNamePredicate(
        IVehicleDrivetrainTypeFilteringRequestParameters requestParameters) =>
        vehicleDrivetrainType => vehicleDrivetrainType.Name.Equals(requestParameters.Name);
}