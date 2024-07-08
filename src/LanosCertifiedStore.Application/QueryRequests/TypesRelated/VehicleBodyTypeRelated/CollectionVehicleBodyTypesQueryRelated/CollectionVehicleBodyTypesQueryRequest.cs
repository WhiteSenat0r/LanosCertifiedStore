using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.TypeDtos;
using Application.Shared.ResultRelated;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.QueryRequests.TypesRelated.VehicleBodyTypeRelated.CollectionVehicleBodyTypesQueryRelated;

public sealed record CollectionVehicleBodyTypesQueryRequest(
    IFilteringRequestParameters<VehicleBodyType> FilteringParameters)
    : ICollectionQueryRequest<VehicleBodyType, PaginationResult<VehicleBodyTypeDto>, VehicleBodyTypeDto>;