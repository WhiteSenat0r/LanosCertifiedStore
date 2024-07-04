using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.QueryRequests.TypesRelated.VehicleTypeRelated.CollectionVehicleTypesQueryRelated;

public sealed record CollectionVehicleTypesQueryRequest(IFilteringRequestParameters<VehicleType> FilteringParameters) :
    ICollectionQueryRequest<VehicleType, PaginationResult<VehicleTypeDto>, VehicleTypeDto>;