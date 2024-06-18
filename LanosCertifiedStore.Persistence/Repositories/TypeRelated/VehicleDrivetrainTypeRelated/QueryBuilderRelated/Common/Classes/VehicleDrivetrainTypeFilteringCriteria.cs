using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated.TypeRelated;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Persistence.Entities.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleDrivetrainTypeRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehicleDrivetrainTypeFilteringCriteria : 
    BaseFilteringCriteria<VehicleDrivetrainType,
        VehicleDrivetrainTypeEntity,
        IVehicleDrivetrainTypeFilteringRequestParameters>
{ 
    internal override Expression<Func<VehicleDrivetrainTypeEntity, bool>> GetCriteria(
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

    private Expression<Func<VehicleDrivetrainTypeEntity, bool>> GetNamePredicate(
        IVehicleDrivetrainTypeFilteringRequestParameters requestParameters) =>
        vehicleDrivetrainType => vehicleDrivetrainType.Name.Equals(requestParameters.Name);
}