using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes;

namespace Domain.Contracts.RepositoryRelated.VehicleRepositoryRelated;

public interface IVehicleRepositoryExtensions
{
    Task<IDictionary<string, decimal>> GetPriceRange(
        IFilteringRequestParameters<Vehicle>? filteringRequestParameters = null!);
}