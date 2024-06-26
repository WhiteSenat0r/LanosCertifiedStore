using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Domain.Models.VehicleRelated.Classes;
using Persistence.Entities.VehicleRelated;
using Persistence.Queries.Common.Classes.QueryRelated;

namespace Persistence.Queries.VehicleBrandRelated.SelectorRelated;

internal sealed class VehicleBrandsFilteringCriteriaSelector : 
    QueryFilteringCriteriaSelectorBase<VehicleBrand, VehicleBrandEntity>
{
    private protected override IReadOnlyCollection<(
        bool IsValid,
        Expression<Func<VehicleBrandEntity, bool>> Expression)> GetAspectMappings(
        IFilteringRequestParameters<VehicleBrand> filteringRequestParameters)
    {
        var brandFilteringRequestParameters = 
            (filteringRequestParameters as IVehicleBrandFilteringRequestParameters)!;

        return new List<(bool IsValid, Expression<Func<VehicleBrandEntity, bool>> Expression)>
        {
            (
                !string.IsNullOrEmpty(brandFilteringRequestParameters.Name),
                vehicleBrand => vehicleBrand.Name.Equals(brandFilteringRequestParameters.Name)
            ),
            (
                !string.IsNullOrEmpty(brandFilteringRequestParameters.ContainedModelName),
                vehicleBrand => vehicleBrand.Models.Any(
                    model => model.Name.Equals(brandFilteringRequestParameters.ContainedModelName))
            )
        };
    }
}