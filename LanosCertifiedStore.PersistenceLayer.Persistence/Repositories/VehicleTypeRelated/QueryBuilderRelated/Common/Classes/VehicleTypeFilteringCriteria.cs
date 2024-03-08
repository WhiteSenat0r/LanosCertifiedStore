using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes.TypesRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehicleTypeRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehicleTypeFilteringCriteria : 
    BaseFilteringCriteria<VehicleType, VehicleTypeDataModel, IVehicleTypeFilteringRequestParameters>
{ 
    internal override Expression<Func<VehicleTypeDataModel, bool>> GetCriteria(
        IFilteringRequestParameters<VehicleType>? filteringRequestParameters)
    { 
        var vehicleTypeFilteringParameters = filteringRequestParameters as IVehicleTypeFilteringRequestParameters;

        return vehicleType =>
            string.IsNullOrEmpty(vehicleTypeFilteringParameters!.Name)
            || vehicleType.Name.Equals(vehicleTypeFilteringParameters.Name);
    }
    
    private protected override void AddPredicateMethodsToList(
        IVehicleTypeFilteringRequestParameters requestParameters)
    {
        if (!string.IsNullOrEmpty(requestParameters.Name)) 
            PredicateDelegates.Add(GetNamePredicate);
    }

    private Expression<Func<VehicleTypeDataModel, bool>> GetNamePredicate(
        IVehicleTypeFilteringRequestParameters requestParameters) =>
        vehicleType => vehicleType.Name.Equals(requestParameters.Name);
}