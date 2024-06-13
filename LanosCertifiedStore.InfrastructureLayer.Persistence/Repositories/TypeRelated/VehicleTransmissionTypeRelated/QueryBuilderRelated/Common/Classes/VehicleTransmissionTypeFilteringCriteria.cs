using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated.TypeRelated;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.TypeRelated.VehicleTransmissionTypeRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehicleTransmissionTypeFilteringCriteria : 
    BaseFilteringCriteria<VehicleTransmissionType,
        VehicleTransmissionTypeDataModel,
        IVehicleTransmissionTypeFilteringRequestParameters>
{ 
    internal override Expression<Func<VehicleTransmissionTypeDataModel, bool>> GetCriteria(
        IFilteringRequestParameters<VehicleTransmissionType>? filteringRequestParameters)
    { 
        var vehicleTransmissionTypeFilteringParameters = filteringRequestParameters as
            IVehicleTransmissionTypeFilteringRequestParameters;

        return vehicleTransmissionType =>
            string.IsNullOrEmpty(vehicleTransmissionTypeFilteringParameters!.Name)
            || vehicleTransmissionType.Name.Equals(vehicleTransmissionTypeFilteringParameters.Name);
    }
    
    private protected override void AddPredicateMethodsToList(
        IVehicleTransmissionTypeFilteringRequestParameters requestParameters)
    {
        if (!string.IsNullOrEmpty(requestParameters.Name)) 
            PredicateDelegates.Add(GetNamePredicate);
    }

    private Expression<Func<VehicleTransmissionTypeDataModel, bool>> GetNamePredicate(
        IVehicleTransmissionTypeFilteringRequestParameters requestParameters) =>
        vehicleTransmissionType => vehicleTransmissionType.Name.Equals(requestParameters.Name);
}