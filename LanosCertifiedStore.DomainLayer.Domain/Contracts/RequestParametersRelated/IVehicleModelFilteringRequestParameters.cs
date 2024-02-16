using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;

namespace Domain.Contracts.RequestParametersRelated;

public interface IVehicleModelFilteringRequestParameters : IFilteringRequestParameters<VehicleModel>
{
    string? Name { get; set; }
    string? ContainedBrandName { get; set; }
}