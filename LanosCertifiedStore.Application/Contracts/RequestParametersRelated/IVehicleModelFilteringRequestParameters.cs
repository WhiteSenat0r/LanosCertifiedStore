using Application.Contracts.Common;
using Domain.Entities.VehicleRelated;

namespace Application.Contracts.RequestParametersRelated;

public interface IVehicleModelFilteringRequestParameters : IFilteringRequestParameters<VehicleModel>
{
    string? ContainedBrandName { get; set; }
}