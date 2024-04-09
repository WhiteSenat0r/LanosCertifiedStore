using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleBodyTypeRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehicleBodyTypeFilteringCriteria : 
    BaseFilteringCriteria<VehicleBodyType, VehicleBodyTypeDataModel, IVehicleBodyTypeFilteringRequestParameters>
{ 
    internal override Expression<Func<VehicleBodyTypeDataModel, bool>> GetCriteria(
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

    private Expression<Func<VehicleBodyTypeDataModel, bool>> GetNamePredicate(
        IVehicleBodyTypeFilteringRequestParameters requestParameters) =>
        vehicleBodyType => vehicleBodyType.Name.Equals(requestParameters.Name);
}