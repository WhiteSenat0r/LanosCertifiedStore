﻿using System.Linq.Expressions;
using LanosCertifiedStore.Application.LocationTowns;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace LanosCertifiedStore.Persistence.Queries.LocationRelated.LocationTownRelated.SelectorRelated;

internal sealed class LocationTownFilteringCriteriaSelector : QueryFilteringCriteriaSelectorBase<VehicleLocationTown>
{
    private protected override IReadOnlyCollection<(bool IsValid, Expression<Func<VehicleLocationTown, bool>> Expression)>
        GetAspectMappings(IFilteringRequestParameters<VehicleLocationTown> filteringRequestParameters)
    {
        var castedParameters = (filteringRequestParameters as ILocationTownFilteringRequestParameters)!;
        
        return
        [
            (
                IsValidAspectId(castedParameters.LocationRegionId), 
                town => town.LocationRegionId.Equals(castedParameters.LocationRegionId!.Value)
            ),
            (
                IsValidAspectId(castedParameters.LocationTownTypeId), 
                town => town.LocationTownTypeId.Equals(castedParameters.LocationTownTypeId!.Value)
            )
        ];
    }

    private bool IsValidAspectId(Guid? checkedId)
    {
        return checkedId.HasValue && !Guid.Empty.Equals(checkedId.Value);
    }
}