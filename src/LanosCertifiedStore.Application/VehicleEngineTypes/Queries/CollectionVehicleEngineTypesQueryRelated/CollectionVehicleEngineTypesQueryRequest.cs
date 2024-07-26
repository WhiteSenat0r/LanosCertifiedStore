using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

namespace LanosCertifiedStore.Application.VehicleEngineTypes.Queries.CollectionVehicleEngineTypesQueryRelated;

public sealed record CollectionVehicleEngineTypesQueryRequest(
    IFilteringRequestParameters<VehicleEngineType> FilteringParameters)
    : ICollectionQueryRequest<VehicleEngineType, PaginationResult<VehicleEngineTypeDto>, VehicleEngineTypeDto>;