using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Domain.Entities.VehicleRelated;

namespace Application.QueryRequests.VehicleColorsRelated.CountVehicleColorsQueryRequestRelated;

public sealed record CountVehicleColorsQueryRequest(IFilteringRequestParameters<VehicleColor> FilteringParameters)
    : ICountQueryRequest<VehicleColor>;