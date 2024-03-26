using System.Linq.Expressions;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehicleImageRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehicleImageFilteringCriteria 
    : BaseFilteringCriteria<VehicleImage, VehicleImageDataModel, IVehicleImageFilteringRequestParameters>
{ 
    internal override Expression<Func<VehicleImageDataModel, bool>> GetCriteria(
        IFilteringRequestParameters<VehicleImage>? filteringRequestParameters)
    {
        if (filteringRequestParameters is not IVehicleImageFilteringRequestParameters requestParameters)
            return GetPredicate();

        AddPredicateMethodsToList(requestParameters);

        return GetPredicate(requestParameters);
    }
    
    private protected override void AddPredicateMethodsToList(
        IVehicleImageFilteringRequestParameters requestParameters)
    {
        if (requestParameters.RelatedVehicleId.HasValue) 
            PredicateDelegates.Add(GetImageRelatedVehicleIdPredicate);
    }
    
    private Expression<Func<VehicleImageDataModel, bool>> GetImageRelatedVehicleIdPredicate(
        IVehicleImageFilteringRequestParameters requestParameters) =>
        vehicleImage => vehicleImage.VehicleId.Equals(requestParameters.RelatedVehicleId!.Value);
}