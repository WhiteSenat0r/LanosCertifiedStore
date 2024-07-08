using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.QueryRequests.TypesRelated.VehicleTransmissionTypeRelated
    .CollectionVehicleTransmissionTypesQueryRelated;

public sealed record CollectionVehicleTransmissionTypesQueryRequest(
    IFilteringRequestParameters<VehicleTransmissionType> FilteringParameters) :
    ICollectionQueryRequest<VehicleTransmissionType, PaginationResult<VehicleTransmissionTypeDto>,
        VehicleTransmissionTypeDto>;