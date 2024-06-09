using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Enums.RequestParametersRelated.TypeRelated;

namespace Domain.Contracts.RequestParametersRelated.TypeRelated;

public interface IVehicleDrivetrainTypeFilteringRequestParameters : IFilteringRequestParameters<VehicleDrivetrainType>
{
    string? Name { get; set; }
    VehicleDrivetrainTypeSelectionProfile SelectionProfile { get; }
}