using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Domain.Models.VehicleRelated.Classes;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehicleRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehicleFilteringCriteria : 
    BaseFilteringCriteria<Vehicle, VehicleDataModel, IVehicleFilteringRequestParameters>
{
    internal override Expression<Func<VehicleDataModel, bool>> GetCriteria(
        IFilteringRequestParameters<Vehicle>? filteringRequestParameters)
    {
        if (filteringRequestParameters is not IVehicleFilteringRequestParameters requestParameters)
            return GetPredicate();

        AddPredicateMethodsToList(requestParameters);

        return GetPredicate(requestParameters);
    }

    private protected override void AddPredicateMethodsToList(
        IVehicleFilteringRequestParameters requestParameters)
    {
        if (!string.IsNullOrEmpty(requestParameters.Brand)) 
            PredicateDelegates.Add(GetBrandNamePredicate);

        if (!string.IsNullOrEmpty(requestParameters.Model)) 
            PredicateDelegates.Add(GetModelNamePredicate);
        
        if (!string.IsNullOrEmpty(requestParameters.Type)) 
            PredicateDelegates.Add(GetTypeNamePredicate);
        
        if (!string.IsNullOrEmpty(requestParameters.Color)) 
            PredicateDelegates.Add(GetColorNamePredicate);
        
        if (requestParameters.LowerPriceLimit.HasValue) 
            PredicateDelegates.Add(GetLowerPriceLimitPredicate);

        if (requestParameters.UpperPriceLimit.HasValue) 
            PredicateDelegates.Add(GetUpperPriceLimitPredicate);
    }

    private Expression<Func<VehicleDataModel, bool>> GetBrandNamePredicate(
        IVehicleFilteringRequestParameters requestParameters) =>
        vehicle => vehicle.Brand.Name.Equals(requestParameters.Brand);
    
    private Expression<Func<VehicleDataModel, bool>> GetModelNamePredicate(
        IVehicleFilteringRequestParameters requestParameters) =>
        vehicle => vehicle.Model.Name.Equals(requestParameters.Model);
    
    private Expression<Func<VehicleDataModel, bool>> GetTypeNamePredicate(
        IVehicleFilteringRequestParameters requestParameters) =>
        vehicle => vehicle.VehicleType.Name.Equals(requestParameters.Type);
    
    private Expression<Func<VehicleDataModel, bool>> GetColorNamePredicate(
        IVehicleFilteringRequestParameters requestParameters) =>
        vehicle => vehicle.Color.Name.Equals(requestParameters.Color);
    
    private Expression<Func<VehicleDataModel, bool>> GetLowerPriceLimitPredicate(
        IVehicleFilteringRequestParameters requestParameters) =>
        vehicle => vehicle.Prices.OrderByDescending(
            price => price.IssueDate).First().Value >= requestParameters.LowerPriceLimit!.Value;
    
    private Expression<Func<VehicleDataModel, bool>> GetUpperPriceLimitPredicate(
        IVehicleFilteringRequestParameters requestParameters) =>
        vehicle => vehicle.Prices.OrderByDescending(
            price => price.IssueDate).First().Value <= requestParameters.UpperPriceLimit!.Value;
}