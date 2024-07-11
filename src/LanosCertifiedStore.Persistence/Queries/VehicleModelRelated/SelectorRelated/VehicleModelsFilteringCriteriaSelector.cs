using System.Linq.Expressions;
using Application.Shared.RequestParamsRelated;
using Application.VehicleModels;
using Domain.Entities.VehicleRelated;
using Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace Persistence.Queries.VehicleModelRelated.SelectorRelated;

internal sealed class VehicleModelsFilteringCriteriaSelector : QueryFilteringCriteriaSelectorBase<VehicleModel>
{
    private protected override IReadOnlyCollection<(bool IsValid, Expression<Func<VehicleModel, bool>> Expression)>
        GetAspectMappings(IFilteringRequestParameters<VehicleModel> filteringRequestParameters)
    {
        var castedParameters = (filteringRequestParameters as IVehicleModelFilteringRequestParameters)!;
        
        return
        [
            (
                IsValidAspectId(castedParameters.VehicleBrandId), 
                model => model.VehicleBrandId.Equals(castedParameters.VehicleBrandId!.Value)
            )
        ];
    }

    private bool IsValidAspectId(Guid? checkedId)
    {
        return checkedId.HasValue && !Guid.Empty.Equals(checkedId.Value);
    }
}