using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.QueryRequests.TypesRelated.VehicleTransmissionTypeRelated.CountTransmissionTypesQueryRelated;

public sealed record CountVehicleTransmissionTypesQueryRequest(
    IFilteringRequestParameters<VehicleTransmissionType> FilteringParameters) : 
    ICountQueryRequest<VehicleTransmissionType>;