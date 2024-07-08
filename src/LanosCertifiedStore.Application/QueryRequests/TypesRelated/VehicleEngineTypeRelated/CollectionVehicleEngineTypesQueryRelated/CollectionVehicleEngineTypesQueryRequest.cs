using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.TypeDtos;
using Application.Shared.ResultRelated;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.QueryRequests.TypesRelated.VehicleEngineTypeRelated.CollectionVehicleEngineTypesQueryRelated;

public sealed record CollectionVehicleEngineTypesQueryRequest(
    IFilteringRequestParameters<VehicleEngineType> FilteringParameters)
    : ICollectionQueryRequest<VehicleEngineType, PaginationResult<VehicleEngineTypeDto>, VehicleEngineTypeDto>;