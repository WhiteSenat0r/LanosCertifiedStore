using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Domain.Models.VehicleRelated.Classes;
using Persistence.Entities.VehicleRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehicleModelRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehicleModelFilteringCriteria 
    : BaseFilteringCriteria<VehicleModel, VehicleModelEntity, IVehicleModelFilteringRequestParameters>
{ 
    internal override Expression<Func<VehicleModelEntity, bool>> GetCriteria(
        IFilteringRequestParameters<VehicleModel>? filteringRequestParameters)
    {
        if (filteringRequestParameters is not IVehicleModelFilteringRequestParameters requestParameters)
            return GetPredicate();

        AddPredicateMethodsToList(requestParameters);
        
        return GetPredicate(requestParameters);
    }

    private protected override void AddPredicateMethodsToList(
        IVehicleModelFilteringRequestParameters requestParameters)
    {
        if (!string.IsNullOrEmpty(requestParameters.Name)) 
            PredicateDelegates.Add(GetModelNamePredicate);

        if (!string.IsNullOrEmpty(requestParameters.ContainedBrandName)) 
            PredicateDelegates.Add(GetContainedBrandNamePredicate);
    }
    
    private Expression<Func<VehicleModelEntity, bool>> GetContainedBrandNamePredicate(
        IVehicleModelFilteringRequestParameters requestParameters) =>
        vehicleModel => vehicleModel.VehicleBrand.Name.Equals(
            requestParameters.ContainedBrandName);

    private Expression<Func<VehicleModelEntity, bool>> GetModelNamePredicate(
        IVehicleModelFilteringRequestParameters requestParameters) =>
        vehicleModel => vehicleModel.Name.Equals(requestParameters.Name);
}