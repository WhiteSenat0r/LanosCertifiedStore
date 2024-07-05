using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.QueryRequests.TypesRelated.VehicleDrivetrainTypeRelated.CollectionVehicleDrivetrainTypesQueryRequestRelated;

public sealed record CollectionVehicleDrivetrainTypesQueryRequest(
    IFilteringRequestParameters<VehicleDrivetrainType> FilteringParameters) :
    ICollectionQueryRequest<VehicleDrivetrainType, PaginationResult<VehicleDrivetrainTypeDto>,
        VehicleDrivetrainTypeDto>;