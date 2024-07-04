using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.ColorDtos;
using Domain.Entities.VehicleRelated;

namespace Application.Contracts.ServicesRelated;

public interface IVehicleColorService
{
    Task<VehicleColorDto> GetVehicleColors(IFilteringRequestParameters<VehicleColor> filteringRequestParameters,
        CancellationToken cancellationToken);
}