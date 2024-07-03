using Application.Contracts.RequestParametersRelated;
using Application.Dtos.ColorDtos;

namespace Application.Contracts.ServicesRelated;

public interface IVehicleColorService
{
    Task<VehicleColorDto> GetVehicleColors(IVehicleColorFilteringRequestParameters filteringRequestParameters,
        CancellationToken cancellationToken);
}