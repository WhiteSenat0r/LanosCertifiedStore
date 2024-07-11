using Application.Shared.RequestParamsRelated;
using Application.Shared.RequestRelated.QueryRelated;
using Application.Shared.ResultRelated;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.VehicleBodyTypes.Queries.CollectionVehicleBodyTypesQueryRelated;

public sealed record CollectionVehicleBodyTypesQueryRequest(
    IFilteringRequestParameters<VehicleBodyType> FilteringParameters)
    : ICollectionQueryRequest<VehicleBodyType, PaginationResult<VehicleBodyTypeDto>, VehicleBodyTypeDto>;