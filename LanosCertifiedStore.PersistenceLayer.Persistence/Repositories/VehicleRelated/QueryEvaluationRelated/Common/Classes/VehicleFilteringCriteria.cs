using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels;
using Persistence.QueryEvaluation.Common;

namespace Persistence.Repositories.VehicleRelated.QueryEvaluationRelated.Common.Classes;

internal class VehicleFilteringCriteria : BaseFilteringCriteria<Vehicle, VehicleDataModel>
{ 
    internal override Expression<Func<VehicleDataModel, bool>> GetCriteria(
        IFilteringRequestParameters<Vehicle>? filteringRequestParameters)
    {
        var vehicleFilteringParameters = filteringRequestParameters as IVehicleFilteringRequestParameters;

        return vehicle =>
            (string.IsNullOrEmpty(vehicleFilteringParameters!.Brand)
             || vehicle.Brand.Name.Equals(vehicleFilteringParameters.Brand)) &&
            (string.IsNullOrEmpty(vehicleFilteringParameters.Type)
             || vehicle.Type.Name.Equals(vehicleFilteringParameters.Type)) &&
            (string.IsNullOrEmpty(vehicleFilteringParameters.Color)
             || vehicle.Color.Name.Equals(vehicleFilteringParameters.Color)) &&
            (!vehicleFilteringParameters.LowerPriceLimit.HasValue ||
             (vehicle.Prices.OrderByDescending(p => p.IssueDate)
               .FirstOrDefault()!.Value >= vehicleFilteringParameters.LowerPriceLimit.Value &&
              vehicle.Prices.OrderByDescending(p => p.IssueDate)
               .FirstOrDefault()!.IssueDate >= vehicleFilteringParameters.MinimalPriceDate)) &&
            (!vehicleFilteringParameters.UpperPriceLimit.HasValue ||
             (vehicle.Prices.OrderByDescending(p => p.IssueDate)
               .FirstOrDefault()!.Value <= vehicleFilteringParameters.UpperPriceLimit.Value &&
              vehicle.Prices.OrderByDescending(p => p.IssueDate)
               .FirstOrDefault()!.IssueDate >= vehicleFilteringParameters.MinimalPriceDate));
    }
}