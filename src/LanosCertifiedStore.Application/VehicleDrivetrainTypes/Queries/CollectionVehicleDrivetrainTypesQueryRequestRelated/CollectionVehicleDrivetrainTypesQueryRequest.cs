using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

namespace LanosCertifiedStore.Application.VehicleDrivetrainTypes.Queries.CollectionVehicleDrivetrainTypesQueryRequestRelated;

public sealed record CollectionVehicleDrivetrainTypesQueryRequest(
    IFilteringRequestParameters<VehicleDrivetrainType> FilteringParameters) :
    ICollectionQueryRequest<VehicleDrivetrainType, PaginationResult<VehicleDrivetrainTypeDto>,
        VehicleDrivetrainTypeDto>;