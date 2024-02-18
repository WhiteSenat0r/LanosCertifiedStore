using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;

namespace Domain.Contracts.RequestParametersRelated;

public interface IVehicleImageFilteringRequestParameters : IFilteringRequestParameters<VehicleImage>
{ 
    Guid? RelatedVehicleId { get; set; }
}