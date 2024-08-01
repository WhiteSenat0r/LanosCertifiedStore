using System.Linq.Expressions;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.VehicleModels;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace LanosCertifiedStore.Persistence.Queries.VehicleModelRelated.SelectorRelated;

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