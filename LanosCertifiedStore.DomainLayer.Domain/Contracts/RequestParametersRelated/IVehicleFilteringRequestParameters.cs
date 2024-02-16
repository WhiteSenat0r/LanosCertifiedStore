using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;

namespace Domain.Contracts.RequestParametersRelated;

public interface IVehicleFilteringRequestParameters : IFilteringRequestParameters<Vehicle>
{
    string? Brand { get; set; }
    string? Type { get; set; }
    string? Color { get; set; }
    double? Displacement { get; set; }
    decimal? LowerPriceLimit { get; set; }
    decimal? UpperPriceLimit { get; set; }
    DateTime? MinimalPriceDate { get; set; }
}