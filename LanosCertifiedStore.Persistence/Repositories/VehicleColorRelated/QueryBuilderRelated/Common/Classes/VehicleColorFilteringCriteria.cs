using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Domain.Models.VehicleRelated.Classes;
using Persistence.Entities.VehicleRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehicleColorRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehicleColorFilteringCriteria : 
    BaseFilteringCriteria<VehicleColor, VehicleColorEntity, IVehicleColorFilteringRequestParameters>
{ 
    internal override Expression<Func<VehicleColorEntity, bool>> GetCriteria(
        IFilteringRequestParameters<VehicleColor>? filteringRequestParameters)
    {
        if (filteringRequestParameters is not IVehicleColorFilteringRequestParameters requestParameters)
            return GetPredicate();

        AddPredicateMethodsToList(requestParameters);
        
        return GetPredicate(requestParameters);
    }
    
    private protected override void AddPredicateMethodsToList(
        IVehicleColorFilteringRequestParameters requestParameters)
    {
        if (!string.IsNullOrEmpty(requestParameters.Name)) 
            PredicateDelegates.Add(GetColorNamePredicate);
    }
    
    private Expression<Func<VehicleColorEntity, bool>> GetColorNamePredicate(
        IVehicleColorFilteringRequestParameters requestParameters) =>
        vehicleColor => vehicleColor.Name.Equals(requestParameters.Name);
}