using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels;
using Persistence.QueryEvaluation.Common;

namespace Persistence.Repositories.VehicleImageRelated.QueryEvaluationRelated.Common.Classes;

internal class VehicleImageFilteringCriteria : BaseFilteringCriteria<VehicleImage, VehicleImageDataModel>
{ 
    internal override Expression<Func<VehicleImageDataModel, bool>> GetCriteria(
        IFilteringRequestParameters<VehicleImage>? filteringRequestParameters)
    { 
        var vehicleImageFilteringParameters = filteringRequestParameters as IVehicleImageFilteringRequestParameters;

        return vehicleImage => !vehicleImageFilteringParameters!.RelatedVehicleId.HasValue
            || vehicleImage.VehicleId.Equals(vehicleImageFilteringParameters.RelatedVehicleId);
    }
}