using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehicleBrandRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehicleBrandFilteringCriteria 
    : BaseFilteringCriteria<VehicleBrand, VehicleBrand, IVehicleBrandFilteringRequestParameters>
{ 
    internal override Expression<Func<VehicleBrand, bool>> GetCriteria(
        IFilteringRequestParameters<VehicleBrand>? filteringRequestParameters)
    {
        if (filteringRequestParameters is not IVehicleBrandFilteringRequestParameters requestParameters)
            return GetPredicate();

        AddPredicateMethodsToList(requestParameters);

        return GetPredicate(requestParameters);
    }

    private protected override void AddPredicateMethodsToList(
        IVehicleBrandFilteringRequestParameters requestParameters)
    {
        if (!string.IsNullOrEmpty(requestParameters.Name)) 
            PredicateDelegates.Add(GetBrandNamePredicate);

        if (!string.IsNullOrEmpty(requestParameters.ContainedModelName)) 
            PredicateDelegates.Add(GetContainedModelNamePredicate);
    }

    private Expression<Func<VehicleBrand, bool>> GetContainedModelNamePredicate(
        IVehicleBrandFilteringRequestParameters requestParameters) =>
        vehicleBrand => vehicleBrand.Models.Any(model => model.Name.Equals(requestParameters.ContainedModelName));

    private Expression<Func<VehicleBrand, bool>> GetBrandNamePredicate(
        IVehicleBrandFilteringRequestParameters requestParameters) =>
        vehicleBrand => vehicleBrand.Name.Equals(requestParameters.Name);
}