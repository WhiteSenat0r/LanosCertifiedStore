using Application.Contracts.RequestParametersRelated;
using Application.Contracts.ServicesRelated;
using Application.Dtos.ColorDtos;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services;

internal sealed class VehicleColorService : IVehicleColorService
{
    public async Task<VehicleColorDto> GetVehicleColors(
        IVehicleColorFilteringRequestParameters filteringRequestParameters,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}