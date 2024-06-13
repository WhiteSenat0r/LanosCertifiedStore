using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Domain.Models.VehicleRelated.Classes;

namespace Application.Contracts.RequestParametersRelated;

public interface IVehicleModelFilteringRequestParameters : IFilteringRequestParameters<VehicleModel>
{
    string? Name { get; set; }
    string? ContainedBrandName { get; set; }
    VehicleModelSelectionProfile SelectionProfile { get; set; }
}