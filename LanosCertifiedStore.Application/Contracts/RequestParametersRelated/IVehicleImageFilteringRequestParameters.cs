using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Domain.Entities.VehicleRelated;

namespace Application.Contracts.RequestParametersRelated;

public interface IVehicleImageFilteringRequestParameters : IFilteringRequestParameters<VehicleImage>
{ 
    Guid? RelatedVehicleId { get; set; }
    VehicleImageSelectionProfile SelectionProfile { get; }
}