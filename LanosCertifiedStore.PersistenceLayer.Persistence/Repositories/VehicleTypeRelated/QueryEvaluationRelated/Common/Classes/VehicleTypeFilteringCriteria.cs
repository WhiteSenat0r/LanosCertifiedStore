using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation.Common;

namespace Persistence.Repositories.VehicleTypeRelated.QueryEvaluationRelated.Common.Classes;

internal class VehicleTypeFilteringCriteria : BaseFilteringCriteria<VehicleType, VehicleTypeDataModel>
{ 
    internal override Expression<Func<VehicleTypeDataModel, bool>> GetCriteria(
        IFilteringRequestParameters<VehicleType>? filteringRequestParameters)
    { 
        var vehicleTypeFilteringParameters = filteringRequestParameters as IVehicleTypeFilteringRequestParameters;

        return vehicleType =>
            string.IsNullOrEmpty(vehicleTypeFilteringParameters!.Name)
            || vehicleType.Name.Equals(vehicleTypeFilteringParameters.Name);
    }
}