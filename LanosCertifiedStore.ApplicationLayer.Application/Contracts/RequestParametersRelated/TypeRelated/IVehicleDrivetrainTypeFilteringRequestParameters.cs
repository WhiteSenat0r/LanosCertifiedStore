using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;

namespace Application.Contracts.RequestParametersRelated.TypeRelated;

public interface IVehicleDrivetrainTypeFilteringRequestParameters : IFilteringRequestParameters<VehicleDrivetrainType>
{
    string? Name { get; set; }
    VehicleDrivetrainTypeSelectionProfile SelectionProfile { get; }
}