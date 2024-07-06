using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.QueryRequests.TypesRelated.VehicleEngineTypeRelated.CountVehicleEngineTypesQueryRelated;

public sealed record CountVehicleEngineTypesQueryRequest(
    IFilteringRequestParameters<VehicleEngineType> FilteringParameters) : ICountQueryRequest<VehicleEngineType>;