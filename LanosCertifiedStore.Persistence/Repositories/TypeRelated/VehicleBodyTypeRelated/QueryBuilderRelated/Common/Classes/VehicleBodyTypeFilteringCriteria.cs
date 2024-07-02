using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleBodyTypeRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehicleBodyTypeFilteringCriteria : 
    BaseFilteringCriteria<VehicleBodyType, VehicleBodyType, IVehicleBodyTypeFilteringRequestParameters>
{ 
    internal override Expression<Func<VehicleBodyType, bool>> GetCriteria(
        IFilteringRequestParameters<VehicleBodyType>? filteringRequestParameters)
    { 
        var vehicleBodyTypeFilteringParameters = filteringRequestParameters as IVehicleBodyTypeFilteringRequestParameters;

        return vehicleBodyType =>
            string.IsNullOrEmpty(vehicleBodyTypeFilteringParameters!.Name)
            || vehicleBodyType.Name.Equals(vehicleBodyTypeFilteringParameters.Name);
    }
    
    private protected override void AddPredicateMethodsToList(
        IVehicleBodyTypeFilteringRequestParameters requestParameters)
    {
        if (!string.IsNullOrEmpty(requestParameters.Name)) 
            PredicateDelegates.Add(GetNamePredicate);
    }

    private Expression<Func<VehicleBodyType, bool>> GetNamePredicate(
        IVehicleBodyTypeFilteringRequestParameters requestParameters) =>
        vehicleBodyType => vehicleBodyType.Name.Equals(requestParameters.Name);
}