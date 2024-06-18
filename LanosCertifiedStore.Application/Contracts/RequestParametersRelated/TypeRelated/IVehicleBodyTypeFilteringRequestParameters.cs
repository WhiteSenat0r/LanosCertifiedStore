using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Domain.Models.VehicleRelated.Classes.TypeRelated;

namespace Application.Contracts.RequestParametersRelated.TypeRelated;

public interface IVehicleBodyTypeFilteringRequestParameters : IFilteringRequestParameters<VehicleBodyType>
{
    string? Name { get; set; }
    VehicleBodyTypeSelectionProfile SelectionProfile { get; }
}