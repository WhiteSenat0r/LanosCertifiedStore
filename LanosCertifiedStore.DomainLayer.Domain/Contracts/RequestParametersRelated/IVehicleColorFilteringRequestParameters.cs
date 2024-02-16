using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;

namespace Domain.Contracts.RequestParametersRelated;

public interface IVehicleColorFilteringRequestParameters : IFilteringRequestParameters<VehicleColor>
{
    string? Name { get; set; }
}