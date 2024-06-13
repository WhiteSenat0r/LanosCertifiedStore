using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated.LocationRelated;
using Domain.Models.VehicleRelated.Classes.LocationRelated;
using Persistence.DataModels.VehicleRelated.LocationRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.LocationRelated.LocationRegionRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehicleLocationRegionFilteringCriteria : 
    BaseFilteringCriteria<VehicleLocationRegion, VehicleLocationRegionDataModel,
        IVehicleLocationRegionFilteringRequestParameters>
{ 
    internal override Expression<Func<VehicleLocationRegionDataModel, bool>> GetCriteria(
        IFilteringRequestParameters<VehicleLocationRegion>? filteringRequestParameters)
    { 
        var vehicleTypeFilteringParameters = filteringRequestParameters 
            as IVehicleLocationRegionFilteringRequestParameters;

        return vehicleType =>
            string.IsNullOrEmpty(vehicleTypeFilteringParameters!.Name)
            || vehicleType.Name.Equals(vehicleTypeFilteringParameters.Name);
    }
    
    private protected override void AddPredicateMethodsToList(
        IVehicleLocationRegionFilteringRequestParameters requestParameters)
    {
        if (!string.IsNullOrEmpty(requestParameters.Name)) 
            PredicateDelegates.Add(GetNamePredicate);
    }

    private Expression<Func<VehicleLocationRegionDataModel, bool>> GetNamePredicate(
        IVehicleLocationRegionFilteringRequestParameters requestParameters) =>
        vehicleType => vehicleType.Name.Equals(requestParameters.Name);
}