using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation.Common;

namespace Persistence.Repositories.VehiclePriceRelated.QueryEvaluationRelated.Common.Classes;

internal class VehiclePriceFilteringCriteria : BaseFilteringCriteria<VehiclePrice, VehiclePriceDataModel>
{ 
    internal override Expression<Func<VehiclePriceDataModel, bool>> GetCriteria(
        IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters)
    {
        var vehiclePriceFilteringParameters = filteringRequestParameters as IVehiclePriceFilteringRequestParameters;

        return vehiclePrice =>
            (!vehiclePriceFilteringParameters.LowerPriceLimit.HasValue
             || vehiclePrice.Value >= vehiclePriceFilteringParameters.LowerPriceLimit) &&
            (!vehiclePriceFilteringParameters.UpperPriceLimit.HasValue
             || vehiclePrice.Value <= vehiclePriceFilteringParameters.LowerPriceLimit);
    }
}