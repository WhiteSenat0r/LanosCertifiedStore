using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

namespace LanosCertifiedStore.Application.VehicleTypes.Queries.CollectionVehicleTypesQueryRelated;

public sealed record CollectionVehicleTypesQueryRequest(IFilteringRequestParameters<VehicleType> FilteringParameters) :
    ICollectionQueryRequest<VehicleType, PaginationResult<VehicleTypeDto>, VehicleTypeDto>;