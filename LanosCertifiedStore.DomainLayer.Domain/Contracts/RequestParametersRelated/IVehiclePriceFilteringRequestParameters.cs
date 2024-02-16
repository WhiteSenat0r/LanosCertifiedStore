using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;

namespace Domain.Contracts.RequestParametersRelated;

public interface IVehiclePriceFilteringRequestParameters : IFilteringRequestParameters<Vehicle>
{
    decimal? LowerPriceLimit { get; set; }
    decimal? UpperPriceLimit { get; set; }
}