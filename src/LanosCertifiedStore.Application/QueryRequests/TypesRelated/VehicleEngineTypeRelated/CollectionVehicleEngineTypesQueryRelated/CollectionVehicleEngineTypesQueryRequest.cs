using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.QueryRequests.TypesRelated.VehicleEngineTypeRelated.CollectionVehicleEngineTypesQueryRelated;

public sealed record CollectionVehicleEngineTypesQueryRequest(
    IFilteringRequestParameters<VehicleEngineType> FilteringParameters)
    : ICollectionQueryRequest<VehicleEngineType, PaginationResult<VehicleEngineTypeDto>, VehicleEngineTypeDto>;