using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.QueryRequests.TypesRelated.VehicleBodyTypeRelated.CollectionVehicleBodyTypesQueryRelated;

public sealed record CollectionVehicleBodyTypesQueryRequest(
    IFilteringRequestParameters<VehicleBodyType> FilteringParameters)
    : ICollectionQueryRequest<VehicleBodyType, PaginationResult<VehicleBodyTypeDto>, VehicleBodyTypeDto>;