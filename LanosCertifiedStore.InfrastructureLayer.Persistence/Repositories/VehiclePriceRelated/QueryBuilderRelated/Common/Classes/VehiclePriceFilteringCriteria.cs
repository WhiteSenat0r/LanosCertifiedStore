using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Domain.Models.VehicleRelated.Classes;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehiclePriceRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehiclePriceFilteringCriteria 
    : BaseFilteringCriteria<VehiclePrice, VehiclePriceDataModel, IVehiclePriceFilteringRequestParameters>
{ 
    internal override Expression<Func<VehiclePriceDataModel, bool>> GetCriteria(
        IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters)
    {
        if (filteringRequestParameters is not IVehiclePriceFilteringRequestParameters requestParameters)
            return GetPredicate();

        AddPredicateMethodsToList(requestParameters);

        return GetPredicate(requestParameters);
    }

    private protected override void AddPredicateMethodsToList(
        IVehiclePriceFilteringRequestParameters requestParameters)
    {
        if (requestParameters.LowerPriceLimit.HasValue) 
            PredicateDelegates.Add(GetLowerLimitPredicate);

        if (requestParameters.UpperPriceLimit.HasValue) 
            PredicateDelegates.Add(GetUpperLimitPredicate);
    }

    private Expression<Func<VehiclePriceDataModel, bool>> GetLowerLimitPredicate(
        IVehiclePriceFilteringRequestParameters requestParameters) =>
        vehiclePrice => vehiclePrice.Value >= requestParameters.LowerPriceLimit!.Value;
    
    private Expression<Func<VehiclePriceDataModel, bool>> GetUpperLimitPredicate(
        IVehiclePriceFilteringRequestParameters requestParameters) =>
        vehiclePrice => vehiclePrice.Value <= requestParameters.UpperPriceLimit!.Value;
}