using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation.Common;

namespace Persistence.Repositories.VehicleModelRelated.QueryEvaluationRelated.Common.Classes;

internal class VehicleModelFilteringCriteria : BaseFilteringCriteria<VehicleModel, VehicleModelDataModel>
{ 
    internal override Expression<Func<VehicleModelDataModel, bool>> GetCriteria(
        IFilteringRequestParameters<VehicleModel>? filteringRequestParameters)
    {
        var vehicleModelFilteringParameters = filteringRequestParameters as IVehicleModelFilteringRequestParameters;

        return vehicleModel =>
            (string.IsNullOrEmpty(vehicleModelFilteringParameters!.Name)
             || vehicleModel.Name.Equals(vehicleModelFilteringParameters.Name)) &&
            (string.IsNullOrEmpty(vehicleModelFilteringParameters.ContainedBrandName)
             || vehicleModel.VehicleBrand.Name.Equals(vehicleModelFilteringParameters.ContainedBrandName));
    }
}