using Application.Shared.RequestParamsRelated;
using Application.Shared.RequestRelated.QueryRelated;
using Application.Shared.ResultRelated;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.VehicleTransmissionTypes.Queries.CollectionVehicleTransmissionTypesQueryRelated;

public sealed record CollectionVehicleTransmissionTypesQueryRequest(
    IFilteringRequestParameters<VehicleTransmissionType> FilteringParameters) :
    ICollectionQueryRequest<VehicleTransmissionType, PaginationResult<VehicleTransmissionTypeDto>,
        VehicleTransmissionTypeDto>;