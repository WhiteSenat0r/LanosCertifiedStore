using Application.Contracts.Common;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.Contracts.RequestParametersRelated;

public interface ILocationAreaFilteringRequestParameters : IFilteringRequestParameters<VehicleLocationArea>
{
    Guid LocationRegionId { get; }
}