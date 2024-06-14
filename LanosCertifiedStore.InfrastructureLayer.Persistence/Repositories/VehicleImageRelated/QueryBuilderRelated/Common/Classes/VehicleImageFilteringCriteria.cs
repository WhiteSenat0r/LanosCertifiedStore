using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Domain.Models.VehicleRelated.Classes;
using Persistence.Entities.VehicleRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehicleImageRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehicleImageFilteringCriteria 
    : BaseFilteringCriteria<VehicleImage, VehicleImageEntity, IVehicleImageFilteringRequestParameters>
{ 
    internal override Expression<Func<VehicleImageEntity, bool>> GetCriteria(
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
    
    private Expression<Func<VehicleImageEntity, bool>> GetImageRelatedVehicleIdPredicate(
        IVehicleImageFilteringRequestParameters requestParameters) =>
        vehicleImage => vehicleImage.VehicleId.Equals(requestParameters.RelatedVehicleId!.Value);
}