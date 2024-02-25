using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation.Common;

namespace Persistence.Repositories.VehicleBrandRelated.QueryEvaluationRelated.Common.Classes;

internal class VehicleBrandFilteringCriteria : BaseFilteringCriteria<VehicleBrand, VehicleBrandDataModel>
{ 
    internal override Expression<Func<VehicleBrandDataModel, bool>> GetCriteria(
        IFilteringRequestParameters<VehicleBrand>? filteringRequestParameters)
    { 
        var vehicleBrandFilteringParameters = filteringRequestParameters as IVehicleBrandFilteringRequestParameters;

        return vehicleBrand =>
            (string.IsNullOrEmpty(vehicleBrandFilteringParameters!.Name)
             || vehicleBrand.Name.Equals(vehicleBrandFilteringParameters.Name)) &&
            (string.IsNullOrEmpty(vehicleBrandFilteringParameters.ContainedModelName)
             || vehicleBrand.Models.Any(model => model.Name.Equals(vehicleBrandFilteringParameters.ContainedModelName)));
    }
}