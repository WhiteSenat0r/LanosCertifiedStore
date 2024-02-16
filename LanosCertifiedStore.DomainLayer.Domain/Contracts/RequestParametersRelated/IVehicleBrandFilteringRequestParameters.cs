using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;

namespace Domain.Contracts.RequestParametersRelated;

public interface IVehicleBrandFilteringRequestParameters : IFilteringRequestParameters<VehicleBrand>
{
    string? Name { get; set; }
    string? ContainedModelName { get; set; }
}