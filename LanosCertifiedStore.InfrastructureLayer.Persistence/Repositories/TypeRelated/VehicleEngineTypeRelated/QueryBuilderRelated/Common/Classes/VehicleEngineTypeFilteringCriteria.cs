using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated.TypeRelated;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Persistence.Entities.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleEngineTypeRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehicleEngineTypeFilteringCriteria : 
    BaseFilteringCriteria<VehicleEngineType, VehicleEngineTypeEntity, IVehicleEngineTypeFilteringRequestParameters>
{ 
    internal override Expression<Func<VehicleEngineTypeEntity, bool>> GetCriteria(
        IFilteringRequestParameters<VehicleEngineType>? filteringRequestParameters)
    { 
        var vehicleEngineTypeFilteringParameters = filteringRequestParameters 
            as IVehicleEngineTypeFilteringRequestParameters;

        return vehicleEngineType =>
            string.IsNullOrEmpty(vehicleEngineTypeFilteringParameters!.Name)
            || vehicleEngineType.Name.Equals(vehicleEngineTypeFilteringParameters.Name);
    }
    
    private protected override void AddPredicateMethodsToList(
        IVehicleEngineTypeFilteringRequestParameters requestParameters)
    {
        if (!string.IsNullOrEmpty(requestParameters.Name)) 
            PredicateDelegates.Add(GetNamePredicate);
    }

    private Expression<Func<VehicleEngineTypeEntity, bool>> GetNamePredicate(
        IVehicleEngineTypeFilteringRequestParameters requestParameters) =>
        vehicleEngineType => vehicleEngineType.Name.Equals(requestParameters.Name);
}