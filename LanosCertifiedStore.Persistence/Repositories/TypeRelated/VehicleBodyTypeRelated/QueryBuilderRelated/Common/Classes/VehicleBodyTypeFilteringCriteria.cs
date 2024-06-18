using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated.TypeRelated;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Persistence.Entities.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleBodyTypeRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehicleBodyTypeFilteringCriteria : 
    BaseFilteringCriteria<VehicleBodyType, VehicleBodyTypeEntity, IVehicleBodyTypeFilteringRequestParameters>
{ 
    internal override Expression<Func<VehicleBodyTypeEntity, bool>> GetCriteria(
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

    private Expression<Func<VehicleBodyTypeEntity, bool>> GetNamePredicate(
        IVehicleBodyTypeFilteringRequestParameters requestParameters) =>
        vehicleBodyType => vehicleBodyType.Name.Equals(requestParameters.Name);
}