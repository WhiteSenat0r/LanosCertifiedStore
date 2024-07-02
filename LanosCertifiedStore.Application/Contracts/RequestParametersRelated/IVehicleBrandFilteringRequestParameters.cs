using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Domain.Entities.VehicleRelated;

namespace Application.Contracts.RequestParametersRelated;

public interface IVehicleBrandFilteringRequestParameters : IFilteringRequestParameters<VehicleBrand>
{
    string? Name { get; set; }
    string? ContainedModelName { get; set; }
    VehicleBrandProjectionProfile ProjectionProfile { get; set; }
}