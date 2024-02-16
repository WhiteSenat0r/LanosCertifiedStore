using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels;
using Persistence.QueryEvaluation.Common;

namespace Persistence.Repositories.VehicleColorRelated.QueryEvaluationRelated.Common.Classes;

internal class VehicleColorFilteringCriteria : BaseFilteringCriteria<VehicleColor, VehicleColorDataModel>
{ 
    internal override Expression<Func<VehicleColorDataModel, bool>> GetCriteria(
        IFilteringRequestParameters<VehicleColor>? filteringRequestParameters)
    { 
        var vehicleColorFilteringParameters = filteringRequestParameters as IVehicleColorFilteringRequestParameters;

        return vehicleColor =>
            string.IsNullOrEmpty(vehicleColorFilteringParameters!.Name)
            || vehicleColor.Name.Equals(vehicleColorFilteringParameters.Name);
    }
}