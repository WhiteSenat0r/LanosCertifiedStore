using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleEngineTypeRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehicleEngineTypeFilteringCriteria : 
    BaseFilteringCriteria<VehicleEngineType, VehicleEngineTypeDataModel, IVehicleEngineTypeFilteringRequestParameters>
{ 
    internal override Expression<Func<VehicleEngineTypeDataModel, bool>> GetCriteria(
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

    private Expression<Func<VehicleEngineTypeDataModel, bool>> GetNamePredicate(
        IVehicleEngineTypeFilteringRequestParameters requestParameters) =>
        vehicleEngineType => vehicleEngineType.Name.Equals(requestParameters.Name);
}