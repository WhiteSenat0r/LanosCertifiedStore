using Application.Shared.RequestParamsRelated;
using Application.Shared.RequestRelated.QueryRelated;
using Application.Shared.ResultRelated;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.VehicleTypes.Queries.CollectionVehicleTypesQueryRelated;

public sealed record CollectionVehicleTypesQueryRequest(IFilteringRequestParameters<VehicleType> FilteringParameters) :
    ICollectionQueryRequest<VehicleType, PaginationResult<VehicleTypeDto>, VehicleTypeDto>;