using Application.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated;

namespace Application.Contracts.RepositoryRelated.VehicleRepositoryRelated;

public interface IVehicleRepositoryExtensions
{
    Task<IDictionary<string, decimal>> GetPriceRange(
        IFilteringRequestParameters<Vehicle>? filteringRequestParameters = null!);
}