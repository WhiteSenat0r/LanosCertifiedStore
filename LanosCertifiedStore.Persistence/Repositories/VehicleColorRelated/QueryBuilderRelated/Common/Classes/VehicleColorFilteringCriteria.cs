using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehicleColorRelated.QueryBuilderRelated.Common.Classes;

internal sealed class VehicleColorFilteringCriteria :
    BaseFilteringCriteria<VehicleColor, VehicleColor, IVehicleColorFilteringRequestParameters>
{
    internal override Expression<Func<VehicleColor, bool>> GetCriteria(
        IFilteringRequestParameters<VehicleColor>? filteringRequestParameters)
    {
        if (filteringRequestParameters is not IVehicleColorFilteringRequestParameters requestParameters)
        {
            return GetPredicate();
        }

        AddPredicateMethodsToList(requestParameters);

        return GetPredicate(requestParameters);
    }

    private protected override void AddPredicateMethodsToList(
        IVehicleColorFilteringRequestParameters requestParameters)
    {
        // if (!string.IsNullOrEmpty(requestParameters.Name))
        // {
        //     PredicateDelegates.Add(GetColorNamePredicate);
        // }
    }

    private Expression<Func<VehicleColor, bool>> GetColorNamePredicate(
        IVehicleColorFilteringRequestParameters requestParameters) => throw new NotImplementedException();
    // vehicleColor => vehicleColor.Name.Equals(requestParameters.Name);
}