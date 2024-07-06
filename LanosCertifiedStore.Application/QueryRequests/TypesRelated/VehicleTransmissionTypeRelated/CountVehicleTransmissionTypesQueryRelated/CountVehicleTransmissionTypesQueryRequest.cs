using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.QueryRequests.TypesRelated.VehicleTransmissionTypeRelated.CountVehicleTransmissionTypesQueryRelated;

public sealed record CountVehicleTransmissionTypesQueryRequest(
    IFilteringRequestParameters<VehicleTransmissionType> FilteringParameters) : 
    ICountQueryRequest<VehicleTransmissionType>;