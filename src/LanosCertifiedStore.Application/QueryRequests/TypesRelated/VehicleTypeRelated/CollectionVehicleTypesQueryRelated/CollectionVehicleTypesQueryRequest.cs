using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.TypeDtos;
using Application.Shared.ResultRelated;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.QueryRequests.TypesRelated.VehicleTypeRelated.CollectionVehicleTypesQueryRelated;

public sealed record CollectionVehicleTypesQueryRequest(IFilteringRequestParameters<VehicleType> FilteringParameters) :
    ICollectionQueryRequest<VehicleType, PaginationResult<VehicleTypeDto>, VehicleTypeDto>;