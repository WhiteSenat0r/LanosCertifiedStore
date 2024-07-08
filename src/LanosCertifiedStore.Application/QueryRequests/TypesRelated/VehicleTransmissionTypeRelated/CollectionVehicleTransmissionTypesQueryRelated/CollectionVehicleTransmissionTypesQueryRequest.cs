using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.TypeDtos;
using Application.Shared.ResultRelated;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.QueryRequests.TypesRelated.VehicleTransmissionTypeRelated
    .CollectionVehicleTransmissionTypesQueryRelated;

public sealed record CollectionVehicleTransmissionTypesQueryRequest(
    IFilteringRequestParameters<VehicleTransmissionType> FilteringParameters) :
    ICollectionQueryRequest<VehicleTransmissionType, PaginationResult<VehicleTransmissionTypeDto>,
        VehicleTransmissionTypeDto>;