using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.TypeDtos;
using Application.Shared.ResultRelated;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.QueryRequests.TypesRelated.VehicleDrivetrainTypeRelated.CollectionVehicleDrivetrainTypesQueryRequestRelated;

public sealed record CollectionVehicleDrivetrainTypesQueryRequest(
    IFilteringRequestParameters<VehicleDrivetrainType> FilteringParameters) :
    ICollectionQueryRequest<VehicleDrivetrainType, PaginationResult<VehicleDrivetrainTypeDto>,
        VehicleDrivetrainTypeDto>;