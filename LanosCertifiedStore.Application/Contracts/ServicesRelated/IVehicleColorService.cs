using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.ColorDtos;
using Domain.Entities.VehicleRelated;

namespace Application.Contracts.ServicesRelated;

public interface IVehicleColorService
{
    // TODO Finish adding all methods, adjust signatures with command requests
    Task<VehicleColorDto> GetVehicleColors(IFilteringRequestParameters<VehicleColor> filteringRequestParameters,
        CancellationToken cancellationToken);
}