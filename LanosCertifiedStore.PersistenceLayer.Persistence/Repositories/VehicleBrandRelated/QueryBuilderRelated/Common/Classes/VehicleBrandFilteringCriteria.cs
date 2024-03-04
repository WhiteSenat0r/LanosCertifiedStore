using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation.Common;

namespace Persistence.Repositories.VehicleBrandRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehicleBrandFilteringCriteria 
    : BaseFilteringCriteria<VehicleBrand, VehicleBrandDataModel, IVehicleBrandFilteringRequestParameters>
{ 
    internal override Expression<Func<VehicleBrandDataModel, bool>> GetCriteria(
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

    private Expression<Func<VehicleBrandDataModel, bool>> GetContainedModelNamePredicate(
        IVehicleBrandFilteringRequestParameters requestParameters) =>
        vehicleBrand => vehicleBrand.Models.Any(model => model.Name.Equals(requestParameters.ContainedModelName));

    private Expression<Func<VehicleBrandDataModel, bool>> GetBrandNamePredicate(
        IVehicleBrandFilteringRequestParameters requestParameters) =>
        vehicleBrand => vehicleBrand.Name.Equals(requestParameters.Name);
}