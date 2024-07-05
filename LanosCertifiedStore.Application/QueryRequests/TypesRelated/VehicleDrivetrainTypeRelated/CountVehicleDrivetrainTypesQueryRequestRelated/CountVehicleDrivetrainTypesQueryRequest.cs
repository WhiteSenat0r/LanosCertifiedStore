using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.QueryRequests.TypesRelated.VehicleDrivetrainTypeRelated.
    CountVehicleDrivetrainTypesQueryRequestRelated;

public sealed record CountVehicleDrivetrainTypesQueryRequest(
    IFilteringRequestParameters<VehicleDrivetrainType> FilteringParameters) : ICountQueryRequest<VehicleDrivetrainType>;