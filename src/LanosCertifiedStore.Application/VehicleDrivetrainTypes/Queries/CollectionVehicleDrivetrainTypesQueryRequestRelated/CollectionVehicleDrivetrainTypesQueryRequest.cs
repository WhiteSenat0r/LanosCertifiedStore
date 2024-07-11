using Application.Shared.RequestParamsRelated;
using Application.Shared.RequestRelated.QueryRelated;
using Application.Shared.ResultRelated;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.VehicleDrivetrainTypes.Queries.CollectionVehicleDrivetrainTypesQueryRequestRelated;

public sealed record CollectionVehicleDrivetrainTypesQueryRequest(
    IFilteringRequestParameters<VehicleDrivetrainType> FilteringParameters) :
    ICollectionQueryRequest<VehicleDrivetrainType, PaginationResult<VehicleDrivetrainTypeDto>,
        VehicleDrivetrainTypeDto>;