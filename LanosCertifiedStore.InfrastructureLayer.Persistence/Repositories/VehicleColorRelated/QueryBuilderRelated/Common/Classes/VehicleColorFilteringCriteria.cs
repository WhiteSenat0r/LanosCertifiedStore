using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehicleColorRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehicleColorFilteringCriteria : 
    BaseFilteringCriteria<VehicleColor, VehicleColorDataModel, IVehicleColorFilteringRequestParameters>
{ 
    internal override Expression<Func<VehicleColorDataModel, bool>> GetCriteria(
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
    
    private Expression<Func<VehicleColorDataModel, bool>> GetColorNamePredicate(
        IVehicleColorFilteringRequestParameters requestParameters) =>
        vehicleColor => vehicleColor.Name.Equals(requestParameters.Name);
}