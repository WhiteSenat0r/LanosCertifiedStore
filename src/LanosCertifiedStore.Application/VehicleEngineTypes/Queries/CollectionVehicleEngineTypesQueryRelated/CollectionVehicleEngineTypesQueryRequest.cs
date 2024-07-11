using Application.Shared.RequestParamsRelated;
using Application.Shared.RequestRelated.QueryRelated;
using Application.Shared.ResultRelated;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.VehicleEngineTypes.Queries.CollectionVehicleEngineTypesQueryRelated;

public sealed record CollectionVehicleEngineTypesQueryRequest(
    IFilteringRequestParameters<VehicleEngineType> FilteringParameters)
    : ICollectionQueryRequest<VehicleEngineType, PaginationResult<VehicleEngineTypeDto>, VehicleEngineTypeDto>;