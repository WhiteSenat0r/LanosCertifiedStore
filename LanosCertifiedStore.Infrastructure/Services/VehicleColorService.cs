using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.ServicesRelated;
using Application.Dtos.ColorDtos;
using Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services;

internal sealed class VehicleColorService : IVehicleColorService
{
    public async Task<VehicleColorDto> GetVehicleColors(
        IFilteringRequestParameters<VehicleColor> filteringRequestParameters,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}