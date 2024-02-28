using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;

namespace Domain.Contracts.RequestParametersRelated;

public interface IVehicleImageFilteringRequestParameters : IFilteringRequestParameters<VehicleImage>
{ 
    Guid? RelatedVehicleId { get; set; }
    VehicleImageSelectionProfile SelectionProfile { get; }
}