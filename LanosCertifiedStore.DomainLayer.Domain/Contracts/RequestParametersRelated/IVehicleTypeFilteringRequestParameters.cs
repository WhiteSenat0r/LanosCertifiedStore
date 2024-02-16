using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;

namespace Domain.Contracts.RequestParametersRelated;

public interface IVehicleTypeFilteringRequestParameters : IFilteringRequestParameters<VehicleType>
{
    string? Name { get; set; }
}