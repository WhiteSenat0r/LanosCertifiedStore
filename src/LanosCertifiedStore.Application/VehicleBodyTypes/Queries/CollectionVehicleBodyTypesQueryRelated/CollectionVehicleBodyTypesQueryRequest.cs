using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

namespace LanosCertifiedStore.Application.VehicleBodyTypes.Queries.CollectionVehicleBodyTypesQueryRelated;

public sealed record CollectionVehicleBodyTypesQueryRequest(
    IFilteringRequestParameters<VehicleBodyType> FilteringParameters)
    : ICollectionQueryRequest<VehicleBodyType, PaginationResult<VehicleBodyTypeDto>, VehicleBodyTypeDto>;