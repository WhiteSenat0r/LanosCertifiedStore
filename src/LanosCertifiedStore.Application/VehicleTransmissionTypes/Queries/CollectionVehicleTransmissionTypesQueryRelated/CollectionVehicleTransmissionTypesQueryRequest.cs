using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

namespace LanosCertifiedStore.Application.VehicleTransmissionTypes.Queries.CollectionVehicleTransmissionTypesQueryRelated;

public sealed record CollectionVehicleTransmissionTypesQueryRequest(
    IFilteringRequestParameters<VehicleTransmissionType> FilteringParameters) :
    ICollectionQueryRequest<VehicleTransmissionType, PaginationResult<VehicleTransmissionTypeDto>,
        VehicleTransmissionTypeDto>;