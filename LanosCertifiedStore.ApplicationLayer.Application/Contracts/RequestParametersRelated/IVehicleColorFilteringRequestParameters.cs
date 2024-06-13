using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Domain.Models.VehicleRelated.Classes;

namespace Application.Contracts.RequestParametersRelated;

public interface IVehicleColorFilteringRequestParameters : IFilteringRequestParameters<VehicleColor>
{
    string? Name { get; set; }
    VehicleColorSelectionProfile SelectionProfile { get; }
}