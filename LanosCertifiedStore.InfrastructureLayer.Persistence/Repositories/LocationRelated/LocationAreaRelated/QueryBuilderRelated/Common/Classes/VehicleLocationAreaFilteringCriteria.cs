using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated.LocationRelated;
using Domain.Models.VehicleRelated.Classes.LocationRelated;
using Persistence.Entities.VehicleRelated.LocationRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.LocationRelated.LocationAreaRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehicleLocationAreaFilteringCriteria : 
    BaseFilteringCriteria<VehicleLocationArea, VehicleLocationAreaEntity,
        IVehicleLocationAreaFilteringRequestParameters>
{ 
    internal override Expression<Func<VehicleLocationAreaEntity, bool>> GetCriteria(
        IFilteringRequestParameters<VehicleLocationArea>? filteringRequestParameters)
    { 
        var vehicleTypeFilteringParameters = filteringRequestParameters 
            as IVehicleLocationAreaFilteringRequestParameters;

        return vehicleType =>
            string.IsNullOrEmpty(vehicleTypeFilteringParameters!.Name)
            || vehicleType.Name.Equals(vehicleTypeFilteringParameters.Name);
    }
    
    private protected override void AddPredicateMethodsToList(
        IVehicleLocationAreaFilteringRequestParameters requestParameters)
    {
        if (!string.IsNullOrEmpty(requestParameters.Name)) 
            PredicateDelegates.Add(GetNamePredicate);
    }

    private Expression<Func<VehicleLocationAreaEntity, bool>> GetNamePredicate(
        IVehicleLocationAreaFilteringRequestParameters requestParameters) =>
        vehicleType => vehicleType.Name.Equals(requestParameters.Name);
}