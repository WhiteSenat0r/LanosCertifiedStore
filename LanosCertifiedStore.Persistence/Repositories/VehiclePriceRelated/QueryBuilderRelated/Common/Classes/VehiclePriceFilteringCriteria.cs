using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehiclePriceRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehiclePriceFilteringCriteria 
    : BaseFilteringCriteria<VehiclePrice, VehiclePrice, IVehiclePriceFilteringRequestParameters>
{ 
    internal override Expression<Func<VehiclePrice, bool>> GetCriteria(
        IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters)
    {
        if (filteringRequestParameters is not IVehiclePriceFilteringRequestParameters requestParameters)
        {
            return GetPredicate();
        }

        AddPredicateMethodsToList(requestParameters);

        return GetPredicate(requestParameters);
    }

    private protected override void AddPredicateMethodsToList(
        IVehiclePriceFilteringRequestParameters requestParameters)
    {
        if (requestParameters.LowerPriceLimit.HasValue)
        {
            PredicateDelegates.Add(GetLowerLimitPredicate);
        }

        if (requestParameters.UpperPriceLimit.HasValue)
        {
            PredicateDelegates.Add(GetUpperLimitPredicate);
        }
    }

    private Expression<Func<VehiclePrice, bool>> GetLowerLimitPredicate(
        IVehiclePriceFilteringRequestParameters requestParameters) =>
        vehiclePrice => vehiclePrice.Value >= requestParameters.LowerPriceLimit!.Value;
    
    private Expression<Func<VehiclePrice, bool>> GetUpperLimitPredicate(
        IVehiclePriceFilteringRequestParameters requestParameters) =>
        vehiclePrice => vehiclePrice.Value <= requestParameters.UpperPriceLimit!.Value;
}